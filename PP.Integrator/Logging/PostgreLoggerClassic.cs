using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Logging;
using Npgsql;
using PP.Integrator.Formatters;
using static PP.Integrator.Logging.LogTableScopesProvider;

namespace PP.Integrator.Logging;

internal sealed partial class PostgreLoggerClassic : PostgreLoggerBase
{
	private BatchBlock<LogRecord>? _batchBuffer;
	private TransformBlock<IEnumerable<LogRecord>, IEnumerable<TableScope>>? _groupBlock;
	private ActionBlock<TableScope>? _writerBlock;
	private TransformManyBlock<IEnumerable<TableScope>, TableScope> _partitionBlock;
	private Thread? _outputThread;

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

		_batchBuffer = new BatchBlock<LogRecord>(MaxBufferItemsCount);

		_groupBlock = new TransformBlock<IEnumerable<LogRecord>, IEnumerable<TableScope>>(GroupByScope, new ExecutionDataflowBlockOptions
		{
			MaxDegreeOfParallelism = maxParallelism,
			BoundedCapacity = Math.Max(1, Environment.ProcessorCount - 1)
		});

		_partitionBlock = new TransformManyBlock<IEnumerable<TableScope>, TableScope>(SplitScopesByPartition, new ExecutionDataflowBlockOptions
		{
			MaxDegreeOfParallelism = maxParallelism,
			/*
			BoundedCapacity = maxParallelism,
			EnsureOrdered = false
			 */
		});

		_writerBlock = new ActionBlock<TableScope>(WriteScopeSafely, new ExecutionDataflowBlockOptions
		{
			MaxDegreeOfParallelism = maxParallelism
		});

		_batchBuffer.LinkTo(_groupBlock, propagateOptions);
		_groupBlock.LinkTo(_partitionBlock, propagateOptions);
		_partitionBlock.LinkTo(_writerBlock, propagateOptions);

		_currentBatchItemsCount = 0;
		_firstBatchItemAtTicks = 0;

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
			while (!_writerBlock.Completion.IsCompleted)
			{
				TryTriggerTimedBatch();
				Thread.Sleep(32);
			}

			if (_writerBlock.Completion.IsFaulted && _writerBlock.Completion.Exception != null)
				ReportLoggingError(nameof(PostgreLoggerClassic), _writerBlock.Completion.Exception);
		}
		catch (Exception error)
		{
			ReportLoggingError(nameof(PostgreLoggerClassic), error);
		}
	}

	protected override void EnqueueEntry(LogRecord entry)
	{
		if (_batchBuffer == null || IsDisposed)
			return;

		while (!_batchBuffer.Post(entry))
		{
			if (IsDisposed || _batchBuffer.Completion.IsCompleted)
				return;

			Thread.Sleep(1);
		}

		if (Interlocked.Increment(ref _currentBatchItemsCount) == 1)
			Interlocked.Exchange(ref _firstBatchItemAtTicks, Stopwatch.GetTimestamp());

#if DEBUG
		_readedCount++;
#endif
	}

	private IEnumerable<TableScope> GroupByScope(IEnumerable<LogRecord> batch)
	{
		HashSet<TableScope> tables = new HashSet<TableScope>();
		var batchCount = 0;
		foreach (var item in batch)
		{
			batchCount++;
			if (item.Scope is not TableScope tableScope)
				continue;

			tableScope.Enqueue(item);
			tables.Add(tableScope);
		}

		if (batchCount > 0 && Interlocked.Add(ref _currentBatchItemsCount, -batchCount) <= 0)
		{
			Interlocked.Exchange(ref _currentBatchItemsCount, 0);
			Interlocked.Exchange(ref _firstBatchItemAtTicks, 0);
		}

		return tables;
	}

	private static IEnumerable<TableScope> SplitScopesByPartition(IEnumerable<TableScope> tableScopes)
	{
		foreach (var partition in tableScopes.Where(static partition => partition.Count > 0))
			yield return partition;
	}

	private void TryTriggerTimedBatch()
	{
		if (_batchBuffer == null)
			return;

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

	private void WriteScope(TableScope tableScope)
	{
		if (tableScope.Count == 0)
			return;

		using var conn = DataSource.OpenConnection();
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

	private void WriteScopeWithRetry(TableScope tableScope)
	{
		if (tableScope.Count == 0)
			return;

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
					Thread.Sleep(++attempt * 100);
				}
				catch (Exception ex)
				{
					lastError = ex;
					break;
				}
			}
			while (attempt <= WriteRetryCount);

			throw lastError ?? new InvalidOperationException($"[{nameof(PostgreLoggerClassic)}] Retry pipeline terminated without explicit error.");
		}
		catch (Exception error)
		{
			ReportLoggingError(nameof(PostgreLoggerClassic), error);
		}
	}

	private void WriteScopeSafely(TableScope tableScope)
	{
		try
		{
			WriteScopeWithRetry(tableScope);
		}
		catch (Exception error)
		{
			ReportLoggingError(nameof(PostgreLoggerClassic), error);
		}
	}

	public override void Flush()
	{
		if (!TryDispose())
			return;

		_batchBuffer?.TriggerBatch();
		_batchBuffer?.Complete();

		if (_outputThread == null)
			return;

		if (_outputThread.Join(ShutdownJoinTimeoutMs))
			return;

		ReportLoggingError(nameof(PostgreLoggerClassic), new TimeoutException($"Не удалось завершить {nameof(PostgreLoggerClassic)} за {ShutdownJoinTimeoutMs} мс."));
	}
}
