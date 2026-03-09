using System.Collections.Immutable;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using Npgsql;
using PP.Integrator.Formatters;

namespace PP.Integrator.Logging
{
	internal sealed partial class PostgreLoggerClassic : PostgreLoggerBase
	{
		private Channel<LogRecord>? _logQueue;
		private NpgsqlDataSource? _source;
		private Thread? _outputThread;
		private CancellationTokenSource? _cancellation;
		private ManualResetEvent? _slim;

#if DEBUG
		int readedCount;
		int writedCount;
#endif
		public PostgreLoggerClassic(
			string contextName,
			Func<NpgsqlConnectionStringBuilder> getCurrentConfig,
			PostgreLoggerProviderOptions options,
			LogLevel defaultLogLevel)
			: base(contextName, getCurrentConfig, options, defaultLogLevel)
		{
		}

		protected override void InitializeCore()
		{
			_slim = new ManualResetEvent(true);
			_source = NpgsqlDataSource.Create(CurrentConfig());
			_cancellation = new CancellationTokenSource();
			var options = new BoundedChannelOptions(MaxBufferItemsCount)
			{
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

		protected override void EnqueueEntry(LogRecord entry)
		{
			var slim = _slim;
			var queue = _logQueue;
			if (slim == null || queue == null)
				return;

			slim.WaitOne();
			queue.Writer.TryWrite(entry);
			if (queue.Reader.Count >= MaxBufferItemsCount)
				slim.Reset();

#if DEBUG
			readedCount++;
#endif
		}

		public override void Flush()
		{
			if (!TryDispose())
				return;

			_cancellation?.Cancel();
			_logQueue?.Writer.TryComplete();
			_slim?.Set();
			_outputThread?.Join(TimeSpan.FromSeconds(30));
			_cancellation?.Dispose();
			_slim?.Dispose();
			_source?.Dispose();
		}

		Queue<LogRecord>? buffer = new();
		Queue<LogRecord>? buffer2;
		Task? currentRead;
		private async void ProcessQueue()
		{
			var cancel = _cancellation;
			if (cancel == null)
				return;

			try
			{
				while (!cancel.IsCancellationRequested)
				{
					if (currentRead == null || currentRead.Status == TaskStatus.RanToCompletion)
						currentRead = ReadToBuffer(cancel.Token);

					await currentRead.ConfigureAwait(false);
					if (buffer == null || buffer.Count < 1)
						continue;

					buffer2 = buffer;
					buffer = null;
					_slim?.Set();
					currentRead = ReadToBuffer(cancel.Token);

					var scopes =
						from item in buffer2
						group item by item.Scope.ToString()
						into patrition
						select new { table = patrition.Key, items = patrition.ToImmutableList() };

					foreach (var scope in scopes)
					{
						WriteScopeWithRetry(scope.table, scope.items, cancel.Token);
					}
				}
			}
			catch (TaskCanceledException)
			{
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception error)
			{
				ReportLoggingError(nameof(PostgreLoggerClassic), error);
			}
		}

		private void WriteScopeWithRetry(string table, IReadOnlyList<LogRecord> items, CancellationToken cancel)
		{
			try
			{
				ExecuteWithRetry(nameof(PostgreLoggerClassic), table, () => WriteScope(table, items, cancel));
			}
			catch (Exception ex)
			{
				ReportLoggingError(nameof(PostgreLoggerClassic), ex);
			}
		}

		private void WriteScope(string table, IReadOnlyList<LogRecord> items, CancellationToken cancel)
		{
			var source = _source;
			if (source == null)
				return;

			using var conn = source.OpenConnection();
			using var writer = conn.BeginBinaryImport(table);
			using var dbWriter = new BulkWriter(writer);
			foreach (var item in items)
			{
				if (cancel.IsCancellationRequested)
					break;

				item.Write(dbWriter, (object?)null);
#if DEBUG
				writedCount++;
#endif
			}
		}

		int readIsWork;
		private async Task ReadToBuffer(CancellationToken cancel)
		{
			var queue = _logQueue;
			if (queue == null)
				return;

			if (Interlocked.Exchange(ref readIsWork, 1) > 0)
				return;
			if (buffer?.Count == MaxBufferItemsCount)
			{
				Interlocked.Decrement(ref readIsWork);
				return;
			}

			var elapsed = 0;
			var position = 0;
			Queue<LogRecord> innerBuffer = new(MaxBufferItemsCount);
			do
			{
				if (queue.Reader.TryRead(out var current))
				{
					innerBuffer.Enqueue(current);
					position++;
					elapsed = 0;
				}
				else
				{
					await Task.Delay(128, cancel);
					elapsed += 128;
				}
			}
			while (elapsed < AutoFlushDuration && position < MaxBufferItemsCount && !cancel.IsCancellationRequested);
			buffer = innerBuffer;
			currentRead = null;
			Interlocked.Decrement(ref readIsWork);
		}
	}
}
