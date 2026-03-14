using System.Diagnostics;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Logging;
using Npgsql;
using PP.Integrator.Formatters;
using static PP.Integrator.Logging.LogTableScopesProvider;

namespace PP.Integrator.Logging;

internal sealed partial class PostgreLoggerClassic : PostgreLoggerBase
{
	private readonly object _syncRoot = new();
	private readonly NpgsqlDataSource _source;

	private LogRecord?[]? _buffer;
	private Thread? _outputThread;
	private bool _isCompleting;
	private int _head;
	private int _tail;
	private int _count;

	private const int ShutdownJoinTimeoutMs = 30000;

#if DEBUG
	private int _readedCount;
	private int _writedCount;
#endif

	public PostgreLoggerClassic(string contextName, NpgsqlDataSource source, PostgreLoggerProviderOptions options)
		: base(contextName, source, options)
	{
		_source = source;
	}

	protected override void InitializeCore()
	{
		_buffer = new LogRecord[MaxBufferItemsCount];
		_head = 0;
		_tail = 0;
		_count = 0;
		_isCompleting = false;

		_outputThread = new Thread(ProcessQueue)
		{
			IsBackground = true,
			Name = "Buffered postgre log queue processing thread"
		};
		_outputThread.Start();
	}

	protected override void EnqueueEntry(LogRecord entry)
	{
		if (_buffer == null || IsDisposed)
			return;

		lock (_syncRoot)
		{
			while (!IsDisposed && !_isCompleting && _count == _buffer.Length)
				Monitor.Wait(_syncRoot);

			if (IsDisposed || _isCompleting)
				return;

			_buffer[_tail] = entry;
			_tail++;
			if (_tail == _buffer.Length)
				_tail = 0;

			_count++;
			Monitor.PulseAll(_syncRoot);

#if DEBUG
			_readedCount++;
#endif
		}
	}

	public override void Flush()
	{
		if (!TryDispose())
			return;

		lock (_syncRoot)
		{
			_isCompleting = true;
			Monitor.PulseAll(_syncRoot);
		}

		if (_outputThread == null)
			return;

		if (_outputThread.Join(ShutdownJoinTimeoutMs))
			return;

		ReportLoggingError(nameof(PostgreLoggerClassic), new TimeoutException($"Не удалось завершить {nameof(PostgreLoggerClassic)} за {ShutdownJoinTimeoutMs} мс."));
	}

	private void ProcessQueue()
	{
		var batch = new List<LogRecord>(MaxBufferItemsCount);
		var groupBlock = new TransformBlock<IEnumerable<LogRecord>, IEnumerable<LogTableScopesProvider.TableScope>>(
			GroupByScope,
			new ExecutionDataflowBlockOptions
			{
				MaxDegreeOfParallelism = Environment.ProcessorCount - 1 
			});
		var writerBlock = new ActionBlock<IEnumerable<LogTableScopesProvider.TableScope>>(
			WriteGroupedBatchSafely,
			new ExecutionDataflowBlockOptions
			{
				MaxDegreeOfParallelism = Environment.ProcessorCount - 1
			});
		groupBlock.LinkTo(writerBlock, new DataflowLinkOptions { PropagateCompletion = true });

		try
		{
			while (TryReadBatch(batch))
			{
				if (!groupBlock.Post(batch.ToArray()))
					break;				
			}

			groupBlock.Complete();
			writerBlock.Completion.Wait();
		}
		catch (Exception error)
		{
			ReportLoggingError(nameof(PostgreLoggerClassic), error);
		}
		finally
		{
			if (!groupBlock.Completion.IsCompleted)
				groupBlock.Complete();

			try
			{
				writerBlock.Completion.Wait();
			}
			catch (Exception completionError)
			{
				ReportLoggingError(nameof(PostgreLoggerClassic), completionError);
			}

			batch.Clear();
		}
	}

	private bool TryReadBatch(List<LogRecord> batch)
	{
		batch.Clear();

		lock (_syncRoot)
		{
			while (_count == 0 && !_isCompleting)
				Monitor.Wait(_syncRoot);

			if (_count == 0)
				return false;

			batch.Add(DequeueCore());

			var deadline = Stopwatch.GetTimestamp() + Stopwatch.Frequency * AutoFlushDuration / 1000;

			while (batch.Count < MaxBufferItemsCount)
			{
				while (_count > 0 && batch.Count < MaxBufferItemsCount)
					batch.Add(DequeueCore());

				Monitor.PulseAll(_syncRoot);

				if (batch.Count == MaxBufferItemsCount)
					break;

				if (_isCompleting && _count == 0)
					break;

				var remaining = GetRemainingMilliseconds(deadline);
				if (remaining <= 0)
					break;

				Monitor.Wait(_syncRoot, remaining);
			}

			Monitor.PulseAll(_syncRoot);
			return batch.Count > 0;
		}
	}

	private LogRecord DequeueCore()
	{
		var item = _buffer![_head]!;
		_buffer[_head] = null;

		_head++;
		if (_head == _buffer!.Length)
			_head = 0;

		_count--;
		return item;
	}

	private static IEnumerable<LogTableScopesProvider.TableScope> GroupByScope(IEnumerable<LogRecord> batch)
	{
		HashSet<TableScope> tables = new HashSet<TableScope>();
		foreach (var item in batch)
		{
			if (item.Scope is not LogTableScopesProvider.TableScope tableScope)
				continue;

			tableScope.Enqueue(item);
			if(!tables.Contains(tableScope))
				tables.Add(tableScope);
		}

		return tables;
	}

	private void WriteGroupedBatchSafely(IEnumerable<LogTableScopesProvider.TableScope> groupedBatch)
	{
		try
		{
			foreach (var partition in groupedBatch)
			{
				if (partition.Count == 0)
					continue;

				WriteScopeWithRetry(partition);
			}
		}
		catch (Exception error)
		{
			ReportLoggingError(nameof(PostgreLoggerClassic), error);
		}
	}

	private void WriteScopeWithRetry(LogTableScopesProvider.TableScope tableScope)
	{
		try
		{
			Exception? lastError = null;
			var table = tableScope.QualifiedTableName;
			var attempt = 0;
			do
			{
				try
				{
					WriteScope(tableScope);
					return;
				}
				catch (Exception ex) when (IsTransientWriteError(ex) && attempt < WriteRetryCount)
				{
					lastError = ex;
					ReportTransientWriteError(nameof(PostgreLoggerClassic), ex, table, attempt + 1, WriteRetryCount);
					Thread.Sleep((attempt + 1) * 100);
					attempt++;
				}
				catch (Exception ex)
				{
					lastError = ex;
					break;
				}
			} while (attempt <= WriteRetryCount);

			throw lastError ?? new InvalidOperationException($"[{nameof(PostgreLoggerClassic)}] Retry pipeline terminated without explicit error.");
		}
		catch (Exception error)
		{
			ReportLoggingError(nameof(PostgreLoggerClassic), error);
		}
	}

	private void WriteScope(LogTableScopesProvider.TableScope tableScope)
	{
		if (tableScope.Count == 0)
			return;

		using var conn = _source.OpenConnection();
		EnsureTableExists(tableScope.QualifiedTableName);
		using var writer = conn.BeginBinaryImport(tableScope.CopyCommand);
		var dbWriter = new BulkWriter(writer);

		while (tableScope.TryDequeue(out var item))
		{
			item.Write(dbWriter, null!);

#if DEBUG
			_writedCount++;
#endif
		}

		writer.Complete();
	}

	private static int GetRemainingMilliseconds(long deadline)
	{
		var remainingTicks = deadline - Stopwatch.GetTimestamp();
		if (remainingTicks <= 0)
			return 0;

		var remainingMs = remainingTicks * 1000 / Stopwatch.Frequency;
		return remainingMs <= 0 ? 1 : (int)remainingMs;
	}
}
