using System.Buffers;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Logging;
using Npgsql;
using PP.Integrator.Formatters;

namespace PP.Integrator.Logging;

internal class PostgreLogger : IDisposable
{
	private BatchBlock<LogRecord> _batchBlock = default!;
	protected readonly NpgsqlDataSource DataSource;
	protected readonly PostgreLoggerProviderOptions Options;
	internal readonly LogTableScopesProvider ScopeProvider;

	private readonly object _initLock = new();

	private static readonly ConcurrentDictionary<string, int> EnsuredTables = new(StringComparer.OrdinalIgnoreCase);
	private static readonly ConcurrentDictionary<string, SemaphoreSlim> TableLocks = new(StringComparer.OrdinalIgnoreCase);

	private Func<bool> _ensureInitializedDelegate;
	private bool _initialized;
	private int _disposed;
	private ulong _written;
	private long _lastErrorLogTicksUtc;

	private BlockingCollection<LogRecord> _buffer = default!;
	private TransformManyBlock<LogRecord[], TablePartition> _groupBlock;
	private ActionBlock<TablePartition> _writerBlock = default!;
	private Thread _consumerThread = null!;
	private readonly CancellationTokenSource _shutdown = new();
	private readonly BufferBackpressure _pressureGate;
	private const int ShutdownJoinTimeoutMs = 5000;

	public PostgreLogger(IPostgreLoggingDataSourceAccessor dataSourceAccessor, PostgreLoggerProviderOptions options)
	{
		DataSource = dataSourceAccessor.DataSource;
		Options = options;
		ScopeProvider = new LogTableScopesProvider(withDefaultScope: true);
		_pressureGate = new BufferBackpressure((uint)Options.MaxBufferItemsCount);
		EnsureInitialized();
	}

	protected int MaxBufferItemsCount => Options.MaxBufferItemsCount;
	protected int AutoFlushDuration => Options.AutoFlushDuration;
	protected int WriteRetryCount => Options.WriteRetryCount;
	protected bool IsDisposed => Volatile.Read(ref _disposed) > 0;

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

		_buffer = new BlockingCollection<LogRecord>(MaxBufferItemsCount);

		var batchSize = Convert.ToInt32(MaxBufferItemsCount * 0.75);

		_batchBlock = new BatchBlock<LogRecord>(batchSize, new GroupingDataflowBlockOptions
		{
			BoundedCapacity = MaxBufferItemsCount,
			CancellationToken = _shutdown.Token
		});

		_groupBlock = new TransformManyBlock<LogRecord[], TablePartition>(GroupByTableName, new ExecutionDataflowBlockOptions
		{
			MaxDegreeOfParallelism = maxParallelism,
			BoundedCapacity = maxParallelism,
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

	protected async ValueTask EnsureTableExistsAsync(TablePartition partition, NpgsqlConnection connection, CancellationToken cancellationToken)
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
		Dictionary<string, TablePartition> tables = new Dictionary<string, TablePartition>(StringComparer.OrdinalIgnoreCase);

		foreach (var row in batch)
		{
			TablePartition partition;

			if (!tables.TryGetValue(row.Scope.Partition.TableName, out partition))
			{
				partition = row.Scope.Partition.IsProcessing ? row.Scope.Partition.NewPartition : row.Scope.Partition;
				tables.Add(partition.TableName, partition);
			}

			partition.Enqueue(row);
			_pressureGate.Increment();
		}

		return tables.Values;
	}

	async Task PartitionEnsuredWrite(TablePartition partition)
	{
		await using var connection = await DataSource.OpenConnectionAsync(_shutdown.Token).ConfigureAwait(false);
		await EnsureTableExistsAsync(partition, connection, _shutdown.Token).ConfigureAwait(false);
		await WritePartitionWithRetry(partition, connection).ConfigureAwait(false);
	}

	private void ProcessQueue()
	{
		try
		{
			var additionalAttempt = 0;
			while (!_shutdown.IsCancellationRequested && !_buffer.IsCompleted)
			{
				var item = _buffer.Take(_shutdown.Token);
				var timeout = new Deadline(AutoFlushDuration);

				do
				{
					if (_buffer.Count < MaxBufferItemsCount * 0.75)
						PreparseItem(item);

					var added = _batchBlock.Post(item);
					var attempt = 0;

					if (!added)
					{
						var writeTimeout = Deadline.FromSeconds(1);

						while (!added && attempt <= WriteRetryCount + additionalAttempt)
						{
							added = _batchBlock.SendAsync(item, _shutdown.Token).Wait(writeTimeout, _shutdown.Token);
							writeTimeout = writeTimeout.Linear(attempt++);
						}
					}

					if (timeout.IsExpired)
					{
						if (_pressureGate.GetPressurePercents() < 90)
							_batchBlock.TriggerBatch();

						timeout = Deadline.BasedOn(timeout);
					}

					if (added)
						timeout = Deadline.BasedOn(timeout);
					else
						ReportLoggingError(new TimeoutException($"Не удалось записать элемент {item} размер буффера вх:{_buffer.Count} вых:{_pressureGate.BufferCount}"));
				}
				while (_buffer.TryTake(out item, timeout, _shutdown.Token) && !_buffer.IsCompleted);
			}

			//_batchBlock.TriggerBatch();
			//_batchBlock.Complete();

			//if (!_writerBlock.Completion.Wait(ShutdownJoinTimeoutMs))
			//	ReportLoggingError(new TimeoutException($"Не удалось дождаться завершения action block за {ShutdownJoinTimeoutMs} мс."));

			//if (_writerBlock.Completion.IsFaulted && _writerBlock.Completion.Exception != null)
			//	ReportLoggingError(_writerBlock.Completion.Exception);
		}
		catch (InvalidOperationException inv)
		{
			ReportLoggingError(inv);
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception error)
		{
			ReportLoggingError(error);
		}
	}

	ArrayBufferWriter<byte> buffer = new ArrayBufferWriter<byte>(2048);
	private void PreparseItem(LogRecord item)
	{
		if (item.GetException() is Exception error)
		{
			BulkWriter.WriteExceptionJsonInternal(error, buffer);
#if NET8_0_OR_GREATER
			item.ErrorBytes = buffer.WrittenSpan.ToArray();
#else
			item.ErrorBytes = buffer.WrittenSpan.ToArray();
#endif
		}

		if (item.GetState() is IReadOnlyList<KeyValuePair<string, object?>> state)
		{
			BulkWriter.WriteStructuredStateInternal(state, buffer);
#if NET8_0_OR_GREATER
			item.StateBytes = buffer.WrittenSpan.ToArray();
#else
			item.ErrorBytes = buffer.WrittenSpan.ToArray();
#endif
		}
	}

	private async Task WritePartition(TablePartition partition, NpgsqlConnection connection)
	{
		await using var importer = await connection.BeginBinaryImportAsync(partition.CopyCommand, _shutdown.Token);

		var writer = new BulkWriter(importer);

		while (partition.TryDequeue(out var item))
		{
			item.Write(writer);
			_pressureGate.Decrement();
		}

		var written = await importer.CompleteAsync(_shutdown.Token);

#if DEBUG
		Interlocked.Add(ref _written, written);
#endif
	}

	private async Task WritePartitionWithRetry(TablePartition partition, NpgsqlConnection connection)
	{
		try
		{
			partition.TryBeginProcessing();
			Exception? lastError = null;
			var attempt = 0;

			do
			{
				try
				{
					await WritePartition(partition, connection);
					lastError = null;
				}
				catch (Exception ex) when (IsTransientWriteError(ex) && attempt < WriteRetryCount)
				{
					lastError = ex;
					ReportLoggingError(ex, $"attempt={attempt + 1}/{WriteRetryCount}");
					await Task.Delay(Deadline.Default.Linear(++attempt, 2), _shutdown.Token);
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
		finally
		{
			partition.EndProcessing();
		}
	}

	private void Flush()
	{
		if (_buffer is not null)
			_buffer.CompleteAdding();

		if (_consumerThread.Join(ShutdownJoinTimeoutMs))
		{
			_batchBlock.TriggerBatch();
			_batchBlock.Complete();

			if (!Task.WaitAll(new[] { _batchBlock.Completion, _groupBlock.Completion, _writerBlock.Completion }, ShutdownJoinTimeoutMs))
			{
				_shutdown.Cancel();
				ReportLoggingError(new TimeoutException($"Не удалось дождаться завершения блоков за {ShutdownJoinTimeoutMs} мс."));
			}
		}
		else
		{
			_shutdown.Cancel();
			ReportLoggingError(new TimeoutException($"Не удалось завершить {nameof(PostgreLogger)} за {ShutdownJoinTimeoutMs} мс."));
		}
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
		if (Interlocked.Exchange(ref _disposed, 1) == 1)
			return;

		try
		{
			Flush();
#if DEBUG
			Console.WriteLine($"Written :{_written} buffer:{_pressureGate.BufferCount} items");
#endif
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
