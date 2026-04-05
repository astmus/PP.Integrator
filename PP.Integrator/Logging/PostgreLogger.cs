using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Logging;
using Npgsql;
using PP.Integrator.Formatters;
using static PP.Integrator.Logging.LogTableScopesProvider;

namespace PP.Integrator.Logging;

internal class PostgreLogger : IDisposable
{
	//protected readonly NpgsqlDataSource DataSource;
	//protected readonly PostgreLoggerProviderOptions Options;
	//internal readonly LogTableScopesProvider ScopeProvider;

	//private readonly object _initLock = new();
	////private static readonly object EnsuredTablesSync = new();
	////private static readonly HashSet<string> EnsuredTables = new(StringComparer.OrdinalIgnoreCase);

	//// поля класса
	//private static readonly ConcurrentDictionary<string, int> EnsuredTables = new(StringComparer.OrdinalIgnoreCase);
	//private static readonly ConcurrentDictionary<string, SemaphoreSlim> TableLocks = new(StringComparer.OrdinalIgnoreCase);

	//private Func<bool> _ensureInitializedDelegate;
	//private bool _initialized;
	//private bool _disposed;
	//private ulong _writed;
	//private long _lastErrorLogTicksUtc;

	private BatchBlock<LogRecord> _batchBlock = default!;
	//private BlockingCollection<LogRecord> _buffer = default!;
	////private BufferBlock<LogRecord> _buffer2 = default!;
	////private TransformBlock<IEnumerable<TablePartition>, TablePartition> _groupBlock = default!;
	//private ActionBlock<TablePartition> _writerBlock = default!;
	//private BufferBlock<TablePartition> _partitionBlock = default!;
	//private Thread _consumerThread = default!;
	//private readonly CancellationTokenSource _shutdown = new();

	

	//private const int ShutdownJoinTimeoutMs = 3000;
	protected readonly NpgsqlDataSource DataSource;
	protected readonly PostgreLoggerProviderOptions Options;
	internal readonly LogTableScopesProvider ScopeProvider;

	private readonly object _initLock = new();

	private static readonly ConcurrentDictionary<string, int> EnsuredTables = new(StringComparer.OrdinalIgnoreCase);
	private static readonly ConcurrentDictionary<string, SemaphoreSlim> TableLocks = new(StringComparer.OrdinalIgnoreCase);

	private Func<bool> _ensureInitializedDelegate;
	private bool _initialized;
	private bool _disposed;
	private ulong _written;
	private long _lastErrorLogTicksUtc;

	private BlockingCollection<LogRecord> _buffer = default!;
	private TransformManyBlock<LogRecord[], TablePartition> _groupBlock;
	private ActionBlock<TablePartition> _writerBlock = default!;
	private Thread _consumerThread = null!;
	private readonly CancellationTokenSource _shutdown = new();	

	private const int ShutdownJoinTimeoutMs = 3000;

	public PostgreLogger(IPostgreLoggingDataSourceAccessor dataSourceAccessor, PostgreLoggerProviderOptions options)
	{
		DataSource = dataSourceAccessor.DataSource;
		Options = options;
		ScopeProvider = new LogTableScopesProvider(withDefaultScope: true);
		_ensureInitializedDelegate = EnsureInitialized;
	}

	protected int MaxBufferItemsCount => Options.MaxBufferItemsCount;
	protected int AutoFlushDuration => Options.AutoFlushDuration;
	protected int WriteRetryCount => Options.WriteRetryCount;
	protected bool IsDisposed => Volatile.Read(ref _disposed);

	public bool IsEnabled(LogLevel logLevel)
		=> logLevel != LogLevel.None;

	internal void WriteEntry(LogRecord entry)
	{
		if (!_ensureInitializedDelegate())
			return;

		while (!(_buffer.IsAddingCompleted || _shutdown.IsCancellationRequested || IsDisposed))
		{
			try
			{
				if (_buffer.TryAdd(entry, 32, _shutdown.Token))
					return;
			}
			catch (OperationCanceledException)
			{
				return;
			}
			catch (InvalidOperationException)
			{
				return;
			}
		}
	}

	protected virtual void Initialize()
	{
		var propagateOptions = new DataflowLinkOptions { PropagateCompletion = true };
		var maxParallelism = Math.Max(1, Environment.ProcessorCount - 1);

		_buffer = new BlockingCollection<LogRecord>(Options.MaxBufferItemsCount);

		_batchBlock = new BatchBlock<LogRecord>(Options.MaxBufferItemsCount, new GroupingDataflowBlockOptions
		{
			BoundedCapacity = MaxBufferItemsCount,
			CancellationToken = _shutdown.Token
		});

		_groupBlock = new TransformManyBlock<LogRecord[], TablePartition>(GroupByTableName, new ExecutionDataflowBlockOptions
		{
			CancellationToken = _shutdown.Token
		});

		_writerBlock = new ActionBlock<TablePartition>(PartitionEnsuredWrite,
			new ExecutionDataflowBlockOptions
			{
				MaxDegreeOfParallelism = maxParallelism,
				BoundedCapacity = maxParallelism,
				CancellationToken = _shutdown.Token
			});


		_batchBlock.LinkTo(_groupBlock, new DataflowLinkOptions { PropagateCompletion = true });
		_groupBlock.LinkTo(_writerBlock, new DataflowLinkOptions { PropagateCompletion = true });		

		_consumerThread = new Thread(ProcessQueue)
		{
			IsBackground = true,
			Name = "Buffered postgre log queue processing thread"
		};
		_consumerThread.Start();
	}

	private bool EnsureInitialized()
	{
		if (IsDisposed)
			return false;

		lock (_initLock)
		{
			if (!_initialized && !IsDisposed)
			{
				Initialize();
				_initialized = true;
			}

			_ensureInitializedDelegate = IsAlive;
			return IsAlive();
		}
	}

	private bool IsAlive()
		=> _initialized && !IsDisposed;

	protected virtual bool IsTransientWriteError(Exception exception) =>
		exception is NpgsqlException or TimeoutException or IOException;

	protected async ValueTask EnsureTableExistsAsync(TablePartition partition, CancellationToken cancellationToken)
	{
		if (EnsuredTables.ContainsKey(partition.TableName))
			return;

		var tableLock = TableLocks.GetOrAdd(partition.TableName, static _ => new SemaphoreSlim(1, 1));

		await tableLock.WaitAsync(cancellationToken).ConfigureAwait(false);
		try
		{
			if (EnsuredTables.ContainsKey(partition.TableName))
				return;

			var qualifiedTableName = partition.TableName;
			var indexName = qualifiedTableName.Replace('.', '_') + "_timestamp_brin_idx";

			await using var connection = await DataSource.OpenConnectionAsync(cancellationToken).ConfigureAwait(false);
			await using var command = connection.CreateCommand();

			command.CommandText =
				$"CREATE SCHEMA IF NOT EXISTS logs; " +
				$"CREATE UNLOGGED TABLE IF NOT EXISTS {qualifiedTableName} " +
				"(timestamp TIMESTAMPTZ, " +
				"loglevel text, " +
				"category TEXT NOT NULL, " +
				"message text, " +
				"eventid integer, " +
				"exception JSONB, " +
				"originalformat text, " +
				"state JSONB); " +
				$"CREATE INDEX IF NOT EXISTS {indexName} " +
				$"ON {qualifiedTableName} USING brin (timestamp);";

			await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
			EnsuredTables.TryAdd(qualifiedTableName, 0);
		}
		finally
		{
			tableLock.Release();
		}
	}

	private IEnumerable<TablePartition> GroupByTableName(LogRecord[] batch)
	{
		var tables =
		(from x in batch
		 group x by x.Scope.Partition.TableName into g
		 select g.First().Scope.Partition)
		.ToArray();

		return tables;
	}

	async Task PartitionEnsuredWrite(TablePartition partition)
	{
		return;
		await EnsureTableExistsAsync(partition, _shutdown.Token).ConfigureAwait(false);
		await WritePartitionWithRetry(partition).ConfigureAwait(false);
	}

	private void ProcessQueue()
	{		
		try
		{			
			while (!_shutdown.IsCancellationRequested && !_buffer.IsCompleted)
			{
				var item = _buffer.Take(_shutdown.Token);				
				var timeout = new Deadline(AutoFlushDuration);

				do
				{					
					EnqueueToPartition(item);
					var added = _batchBlock.Post(item);
					var attempt = WriteRetryCount;
					var writeTimeout = new Deadline(128);

					while (!added && attempt > 0)
					{
						added = _batchBlock.SendAsync(item, _shutdown.Token).Wait(writeTimeout, _shutdown.Token);
						attempt--;
					}

					if (timeout.IsExpired)
					{
						_batchBlock.TriggerBatch();
						break;
					}

					if (added)
						timeout = Deadline.New(timeout);
					else
						ReportLoggingError(new TimeoutException($"Не удалось записать элемент {item}"));
				}
				while (_buffer.TryTake(out item, timeout, _shutdown.Token) && !_buffer.IsCompleted);
			}

			_batchBlock.TriggerBatch();
			_batchBlock.Complete();

			if (!_writerBlock.Completion.Wait(ShutdownJoinTimeoutMs))
				ReportLoggingError(new TimeoutException($"Не удалось дождаться завершения action block за {ShutdownJoinTimeoutMs} мс."));

			if (_writerBlock.Completion.IsFaulted && _writerBlock.Completion.Exception != null)
				ReportLoggingError(_writerBlock.Completion.Exception);
		}		
		catch (InvalidOperationException)
		{
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception error)
		{
			ReportLoggingError(error);
		}
	}

	private void EnqueueToPartition(LogRecord item)
	{
		
		if (_buffer.Count < _buffer.Count * 0.75)
		{
			
		}
		else
			item.Scope.Partition.Enqueue(item);
	}

	private async Task WritePartition(TablePartition tablePartition)
	{
		await using var connection = await DataSource.OpenConnectionAsync(_shutdown.Token);
		await using var importer = await connection.BeginBinaryImportAsync(tablePartition.CopyCommand, _shutdown.Token);

		var writer = new BulkWriter(importer);

		while (tablePartition.TryDequeue(out var item))
			item.Write(writer);

		var written = await importer.CompleteAsync(_shutdown.Token);

#if DEBUG
		Interlocked.Add(ref _written, written);
#endif
	}

	private async Task WritePartitionWithRetry(TablePartition tablePartition)
	{
		try
		{
			Exception? lastError = null;
			var attempt = 0;

			do
			{
				try
				{
					await WritePartition(tablePartition);
					lastError = null;
				}
				catch (Exception ex) when (IsTransientWriteError(ex) && attempt < WriteRetryCount)
				{
					lastError = ex;
					ReportLoggingError(ex, $"attempt={attempt + 1}/{WriteRetryCount}");
					await Task.Delay(++attempt * 100, _shutdown.Token);
				}
			}
			while (!_shutdown.IsCancellationRequested && lastError != null && attempt <= WriteRetryCount);

			if (lastError != null)
				throw lastError;
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception error)
		{
			ReportLoggingError(error);
		}
	}

	private void Flush()
	{
		if (_buffer is null)
			return;

		if (_consumerThread.Join(ShutdownJoinTimeoutMs))
		{
			_batchBlock.Complete();
			_batchBlock.TriggerBatch();

			if (!_writerBlock.Completion.Wait(ShutdownJoinTimeoutMs))
			{
				_shutdown.Cancel();
				ReportLoggingError(new TimeoutException($"Не удалось дождаться завершения {nameof(_writerBlock)} за {ShutdownJoinTimeoutMs} мс."));
			}
		}
		else
		{
			_shutdown.Cancel();
			ReportLoggingError(new TimeoutException($"Не удалось завершить {nameof(PostgreLogger)} за {ShutdownJoinTimeoutMs} мс."));
		}

#if DEBUG
		Console.WriteLine($"writed :{_written}");
#endif
	}

	protected void ReportLoggingError(Exception error, string message = default!, [CallerMemberName] string loggerName = default!)
	{
#if DEBUG
		var nowTicks = DateTime.UtcNow.Ticks;
		var prevTicks = Interlocked.Read(ref _lastErrorLogTicksUtc);
		if (nowTicks - prevTicks < TimeSpan.FromSeconds(5).Ticks)
			return;

		Interlocked.Exchange(ref _lastErrorLogTicksUtc, nowTicks);
		Console.Error.WriteLine($"[{loggerName}] {error.GetType().Name}: {error.Message} {message}");

		if (error.InnerException is Exception innerError)
			ReportLoggingError(innerError, message, loggerName);
#endif
	}

	public void Dispose()
	{
		if (IsDisposed)
			return;

		Volatile.Write(ref _disposed, true);

		try
		{
			if (!_buffer.IsAddingCompleted)
				_buffer.CompleteAdding();

			Flush();
		}
		catch (Exception ex)
		{
			ReportLoggingError(ex);
		}
		finally
		{
			try
			{
				if (!_shutdown.IsCancellationRequested)
					_shutdown.Cancel();
			}
			catch (ObjectDisposedException)
			{
			}
			finally
			{
				_shutdown.Dispose();
			}
		}

		GC.SuppressFinalize(this);
	}
}
