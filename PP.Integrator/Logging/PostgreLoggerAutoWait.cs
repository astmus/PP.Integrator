using System.Diagnostics;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using Npgsql;
using PP.Integrator.Formatters;

namespace PP.Integrator.Logging;

internal sealed partial class PostgreLoggerAutoWait : PostgreLoggerBase
{
	private const int SHUTDOWN_JOIN_TIMEOUT_MS = 30000;

	private AutoResetEvent? _dataArrived;
	private CancellationTokenSource? _cancellation;
	private Channel<LogRecord>? _logQueue;
	private Thread? _outputThread;
	private NpgsqlDataSource? _source;
	private AutoResetEvent? _spaceAvailable;

#if DEBUG
	int readedCount;
	int writedCount;
#endif

	public PostgreLoggerAutoWait(string contextName, IPostgreLoggingDataSourceAccessor dataSourceAccessor, PostgreLoggerProviderOptions options)
		: base(contextName, dataSourceAccessor, options) { }

	private static void ClearPartitions(Dictionary<string, List<LogRecord>> partitions)
	{
		foreach (var items in partitions.Values)
			items.Clear();

		partitions.Clear();
	}

	private void DrainRemaining(Channel<LogRecord> queue, NpgsqlDataSource source, List<LogRecord> batch, Dictionary<string, List<LogRecord>> partitions, CancellationToken cancel)
	{
		batch.Clear();
		while (queue.Reader.TryRead(out var item))
		{
			batch.Add(item);
			if (batch.Count >= MaxBufferItemsCount)
				WriteBatchSafely(source, batch, partitions, cancel);
		}

		if (batch.Count > 0)
			WriteBatchSafely(source, batch, partitions, cancel);
	}

	protected override void EnqueueEntry(LogRecord entry)
	{
		var queue = _logQueue;
		var cancel = _cancellation;
		var dataSignal = _dataArrived;
		var spaceSignal = _spaceAvailable;
		if (queue == null || cancel == null || dataSignal == null || spaceSignal == null)
			return;

		while (!cancel.IsCancellationRequested && !IsDisposed)
		{
			if (queue.Writer.TryWrite(entry))
			{
				dataSignal.Set();
				return;
			}

			spaceSignal.WaitOne(4);
		}

#if DEBUG
		readedCount++;
#endif
	}

	public override void Flush()
	{
		if (!TryDispose())
			return;

#if DEBUG
		Console.WriteLine($"Flushing");
#endif
		var queue = _logQueue;
		var cancel = _cancellation;
		var dataSignal = _dataArrived;
		var spaceSignal = _spaceAvailable;
		var worker = _outputThread;

		queue?.Writer.TryComplete();
		dataSignal?.Set();
		spaceSignal?.Set();
		if (worker != null && !worker.Join(SHUTDOWN_JOIN_TIMEOUT_MS))
		{
			cancel?.Cancel();
			dataSignal?.Set();
			spaceSignal?.Set();
			worker.Join();
		}

		cancel?.Dispose();
		dataSignal?.Dispose();
		spaceSignal?.Dispose();
#if DEBUG
		Console.WriteLine($"read {readedCount} write {writedCount}");
#endif
	}

	protected override void InitializeCore()
	{
		_dataArrived = new AutoResetEvent(false);
		_spaceAvailable = new AutoResetEvent(false);
		_source = DataSource;
		_cancellation = new CancellationTokenSource();

		var options = new BoundedChannelOptions(MaxBufferItemsCount)
		{
			FullMode = BoundedChannelFullMode.Wait,
			SingleReader = true,
			SingleWriter = false
		};

		_logQueue = Channel.CreateBounded<LogRecord>(options);
		_outputThread = new Thread(ProcessQueue)
		{
			IsBackground = true,
			Name = "Buffered postgre log queue processing thread"
		};
		_outputThread.Start();
	}

	private void ProcessQueue()
	{
		var queue = _logQueue;
		var cancel = _cancellation;
		var dataSignal = _dataArrived;
		var spaceSignal = _spaceAvailable;
		var source = _source;
		if (queue == null || cancel == null || dataSignal == null || spaceSignal == null || source == null)
			return;

		var batch = new List<LogRecord>(MaxBufferItemsCount);
		var partitions = new Dictionary<string, List<LogRecord>>(StringComparer.Ordinal);
#if DEBUG
		Console.WriteLine($"{DateTime.UtcNow} read {readedCount} write {writedCount}");
#endif
		try
		{
			while (TryReadBatch(queue, dataSignal, spaceSignal, batch, cancel.Token))
				WriteBatchSafely(source, batch, partitions, cancel.Token);

			DrainRemaining(queue, source, batch, partitions, cancel.Token);
		}
		catch (TaskCanceledException)
		{ }
		catch (OperationCanceledException)
		{ }
		catch (Exception error)
		{
			ReportLoggingError(nameof(PostgreLoggerAutoWait), error);
		}
	}

	private bool TryReadBatch(Channel<LogRecord> queue, AutoResetEvent dataSignal, AutoResetEvent spaceSignal, List<LogRecord> batch, CancellationToken cancel)
	{
		batch.Clear();
		if (!TryReadFirst(queue, dataSignal, out var first, cancel))
			return false;

		batch.Add(first);
		spaceSignal.Set();
		var timer = Stopwatch.StartNew();
		while (batch.Count < MaxBufferItemsCount && timer.ElapsedMilliseconds < AutoFlushDuration && !cancel.IsCancellationRequested)
		{
			while (batch.Count < MaxBufferItemsCount && queue.Reader.TryRead(out var current))
			{
				batch.Add(current);
				spaceSignal.Set();
			}

			var remaining = AutoFlushDuration - (int)timer.ElapsedMilliseconds;
			if (batch.Count >= MaxBufferItemsCount || remaining <= 0 || cancel.IsCancellationRequested)
				break;

			dataSignal.WaitOne(remaining);
		}

		return batch.Count > 0;
	}

	private static bool TryReadFirst(Channel<LogRecord> queue, AutoResetEvent dataSignal, out LogRecord first, CancellationToken cancel)
	{
		while (!cancel.IsCancellationRequested)
		{
			if (queue.Reader.TryRead(out first!))
				return true;

			if (queue.Reader.Completion.IsCompleted)
				return SetFalse(out first);

			dataSignal.WaitOne(64);
		}

		return SetFalse(out first);

		static bool SetFalse(out LogRecord result)
		{
			result = null!;
			return false;
		}
	}

	private void WriteBatch(NpgsqlDataSource source, List<LogRecord> batch, Dictionary<string, List<LogRecord>> partitions, CancellationToken cancel)
	{
		if (batch.Count == 0)
			return;

		foreach (var item in batch.Where(static item => item.Scope != null))
		{
			if (item.Scope is not string table || string.IsNullOrWhiteSpace(table))
				continue;

			if (!partitions.TryGetValue(table, out var items))
			{
				items = new List<LogRecord>();
				partitions[table] = items;
			}

			items.Add(item);
		}

		if (partitions.Count == 0)
			return;

		WriteBatchWithRetry(source, partitions, cancel);
	}

	private void WriteBatchCore(NpgsqlDataSource source, Dictionary<string, List<LogRecord>> partitions, CancellationToken cancel)
	{
		using var conn = source.OpenConnection();
		foreach (var partition in partitions.Where(static partition => partition.Value.Count > 0))
		{
			if (cancel.IsCancellationRequested)
				return;

			WritePartition(conn, partition.Key, partition.Value, cancel);
		}
	}

	private void WriteBatchSafely(NpgsqlDataSource source, List<LogRecord> batch, Dictionary<string, List<LogRecord>> partitions, CancellationToken cancel)
	{
		try
		{
			WriteBatch(source, batch, partitions, cancel);
		}
		catch (Exception writeError)
		{
			ReportLoggingError(nameof(PostgreLoggerAutoWait), writeError);
		}
		finally
		{
			ClearPartitions(partitions);
			batch.Clear();
		}
	}

	private void WriteBatchWithRetry(NpgsqlDataSource source, Dictionary<string, List<LogRecord>> partitions, CancellationToken cancel)
	{
		try
		{
			Exception? lastError = null;
			var attempt = 0;
			do
			{
				try
				{
					WriteBatchCore(source, partitions, cancel);
					return;
				}
				catch (Exception ex) when (IsTransientWriteError(ex) && attempt < WriteRetryCount)
				{
					lastError = ex;
					ReportTransientWriteError(nameof(PostgreLoggerAutoWait), ex, "<batch>", attempt + 1, WriteRetryCount);
					Thread.Sleep((attempt + 1) * 100);
					attempt++;
				}
				catch (Exception ex)
				{
					lastError = ex;
					break;
				}
			} while (attempt <= WriteRetryCount);

			throw lastError ?? new InvalidOperationException($"[{nameof(PostgreLoggerAutoWait)}] Retry pipeline terminated without explicit error.");
		}
		catch (Exception ex)
		{
			ReportLoggingError(nameof(PostgreLoggerAutoWait), ex);
		}
	}

	private void WritePartition(NpgsqlConnection conn, string tableName, List<LogRecord> items, CancellationToken cancel)
	{
		if (items.Count == 0)
			return;

		EnsureTableExists(tableName);
		var copyCommand = TableScopeResolver.BuildCopyCommand(tableName);
		using var writer = conn.BeginBinaryImport(copyCommand);
		var dbWriter = new BulkWriter(writer);

		foreach (var item in items)
		{
			if (cancel.IsCancellationRequested)
				break;

			item.Write(dbWriter, null!);
#if DEBUG
			writedCount++;
#endif
		}

		writer.Complete();
	}
}
