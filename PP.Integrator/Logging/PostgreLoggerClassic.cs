using System.Diagnostics;
using System.Threading.Tasks.Dataflow;
using PP.Integrator.Formatters;
using static PP.Integrator.Logging.LogTableScopesProvider;

namespace PP.Integrator.Logging;

internal sealed partial class PostgreLoggerClassic : PostgreLoggerBase
{
	private BatchBlock<LogRecord> _batchBuffer;
	private TransformBlock<IEnumerable<LogRecord>, IEnumerable<TablePartition>> _groupBlock;
	private ActionBlock<TablePartition> _writerBlock;
	private TransformManyBlock<IEnumerable<TablePartition>, TablePartition> _partitionBlock;
	private Thread _outputThread;
	private readonly CancellationTokenSource _shutdown = new();

	private int _currentBatchItemsCount;
	private long _firstBatchItemAtTicks;

	private const int ShutdownJoinTimeoutMs = 30000;

#if DEBUG
	private int _readedCount;
	private int _writedCount;
#endif

	public PostgreLoggerClassic(string contextName, IPostgreLoggingDataSourceAccessor source, PostgreLoggerProviderOptions options)
		: base(contextName, source, options)
	{
	}

	protected override void InitializeCore()
	{
		var propagateOptions = new DataflowLinkOptions { PropagateCompletion = true };
		var maxParallelism = Math.Max(1, Environment.ProcessorCount - 1); //если в система один процессор то Environment.ProcessorCount - 1 вернет 0

		_batchBuffer = new BatchBlock<LogRecord>(MaxBufferItemsCount,
			new GroupingDataflowBlockOptions
			{
				BoundedCapacity = Convert.ToInt32(MaxBufferItemsCount*1.25),
				CancellationToken = _shutdown.Token
			});

		_groupBlock = new TransformBlock<IEnumerable<LogRecord>, IEnumerable<TablePartition>>(GroupByScope, new ExecutionDataflowBlockOptions
		{
			MaxDegreeOfParallelism = maxParallelism,
			BoundedCapacity = Math.Max(1, Environment.ProcessorCount - 1),
			CancellationToken = _shutdown.Token
		});

		_partitionBlock = new TransformManyBlock<IEnumerable<TablePartition>, TablePartition>(SplitPartitionsByCount, new ExecutionDataflowBlockOptions
		{
			MaxDegreeOfParallelism = maxParallelism,
			CancellationToken = _shutdown.Token,
		});

		_writerBlock = new ActionBlock<TablePartition>(WritePartitionWithRetry, new ExecutionDataflowBlockOptions
		{
			MaxDegreeOfParallelism = maxParallelism,   
			CancellationToken = _shutdown.Token
		});

		_batchBuffer.LinkTo(_groupBlock, propagateOptions);
		_groupBlock.LinkTo(_partitionBlock, propagateOptions);
		_partitionBlock.LinkTo(_writerBlock, propagateOptions);

		_outputThread = new Thread(ProcessQueue)
		{
			IsBackground = true,
			Name = "Buffered postgre log queue processing thread"
		};
		_outputThread.Start();
	}

	private void ProcessQueue()
	{
		try
		{
			while (!_shutdown.IsCancellationRequested && !_writerBlock.Completion.IsCompleted)
			{
				TryTriggerTimedBatch();
				Thread.Sleep(32);
			}

			if (_writerBlock?.Completion.IsFaulted == true && _writerBlock.Completion.Exception != null)
			{
				ReportLoggingError(_writerBlock.Completion.Exception);
				return;
			}
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception error)
		{
			ReportLoggingError(error);
		}
	}

	internal override void EnqueueEntry(LogRecord entry)
	{
		while (!(IsDisposed || _shutdown.IsCancellationRequested || _batchBuffer.Completion.IsCompleted)
			&& !_batchBuffer.Post(entry))
			Thread.Sleep(1);

		if (Interlocked.Increment(ref _currentBatchItemsCount) == 1)
			Interlocked.Exchange(ref _firstBatchItemAtTicks, Stopwatch.GetTimestamp());

#if DEBUG
		Interlocked.Increment(ref _readedCount);
#endif
	}

	private IEnumerable<TablePartition> GroupByScope(IEnumerable<LogRecord> batch)
	{
		var partitions = new Dictionary<TableScope, TablePartition>();
		var batchCount = 0;

		foreach (var item in batch)
		{
			if (item.Scope is not TableScope tableScope)
				throw new ArgumentException("Ожидался scope типа LogTableScopesProvider.TableScope.", nameof(batch));

			if (!partitions.TryGetValue(tableScope, out var partition))
			{
				partition = new TablePartition
				{
					QualifiedTableName = tableScope.QualifiedTableName,
					CopyCommand = tableScope.CopyCommand
				};

				partitions.Add(tableScope, partition);
				batchCount++; 
			}

			partition.Enqueue(item);
		}

		if (batchCount > 0 && Interlocked.Add(ref _currentBatchItemsCount, -batchCount) <= 0)
		{
			Interlocked.Exchange(ref _currentBatchItemsCount, 0);
			Interlocked.Exchange(ref _firstBatchItemAtTicks, 0);
		}

		return partitions.Values;
	}

	private static IEnumerable<TablePartition> SplitPartitionsByCount(IEnumerable<TablePartition> groupedBatch)
	{
		foreach (var partition in groupedBatch.Where(static partition => partition.Count > 0))
			yield return partition;
	}

	private void TryTriggerTimedBatch()
	{
		if (_batchBuffer == null)
			ArgumentNullException.ThrowIfNull(_batchBuffer);

		if (Volatile.Read(ref _currentBatchItemsCount) <= 0)
			return;

		var firstItemTicks = Volatile.Read(ref _firstBatchItemAtTicks);
		if (firstItemTicks == 0)
			return;

		var elapsedMs = (Stopwatch.GetTimestamp() - firstItemTicks) * 1000.0 / Stopwatch.Frequency;
		if (elapsedMs < AutoFlushDuration)
			return;

		_batchBuffer.TriggerBatch();
	}

	private void WritePartition(TablePartition tablePartition)
	{
		if (_shutdown.IsCancellationRequested) return;
		using var connection = DataSource.OpenConnection();

		if (_shutdown.IsCancellationRequested) return;
		EnsureTableExists(connection, tablePartition.QualifiedTableName);

		if (_shutdown.IsCancellationRequested) return;
		using var importer = connection.BeginBinaryImport(tablePartition.CopyCommand);

		var writer = new BulkWriter(importer);

		while (!_shutdown.IsCancellationRequested && tablePartition.TryDequeue(out var item))
		{			
			item.Write(writer);
#if DEBUG
			Interlocked.Increment(ref _writedCount);
#endif
		}

		importer.Complete();
	}

	private void WritePartitionWithRetry(TablePartition tablePartition)
	{
		if (_shutdown.IsCancellationRequested) return;

		try
		{
			Exception? lastError = null;
			var table = tablePartition.QualifiedTableName;
			var attempt = 0;

			do
			{
				try
				{
					WritePartition(tablePartition);
					lastError = null;
				}
				catch (Exception ex) when (IsTransientWriteError(ex) && attempt < WriteRetryCount)
				{
					lastError = ex;
					ReportLoggingError((ex), $"attempt={+attempt}/{WriteRetryCount}");

					_shutdown.Token.WaitHandle.WaitOne(attempt * 100);
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

	protected override void FlushCore()
	{
		_batchBuffer?.TriggerBatch();
		_batchBuffer?.Complete();

		if (!_shutdown.IsCancellationRequested)
			_shutdown.Cancel();

		if (_outputThread.Join(ShutdownJoinTimeoutMs))
			return;

		ReportLoggingError(new TimeoutException($"Не удалось завершить {nameof(PostgreLoggerClassic)} за {ShutdownJoinTimeoutMs} мс."));
	}

	protected override void DisposeCore(bool disposing)
	{
		if (!disposing)
			return;

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
}
