using System.Collections.Immutable;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using Npgsql;
using PP.Integrator.Formatters;

namespace PP.Integrator.Logging
{
	internal sealed partial class PostgreLogger : ILogger
	{
		private readonly string _contextName;
		private readonly Func<NpgsqlConnectionStringBuilder> _currentConfig;
		private LogTableScopesProvider _scopeProvider;
		private Channel<LogRecord> _logQueue;
		private NpgsqlDataSource _source;
		private Thread _outputThread;
		private Action? _initialize;
		private CancellationTokenSource _cancellation;
		private ManualResetEvent _slim;
		private int BUFFER_SIZE = -1;
		private const ushort WRITE_TIME_THRESHOLD = 8192;

		public PostgreLogger(string contextName, Func<NpgsqlConnectionStringBuilder> getCurrentConfig)
		{
			_contextName = contextName;
			_currentConfig = getCurrentConfig;
			_initialize = Initialize;
		}

		void Initialize()
		{
			_initialize = null;
			_slim = new ManualResetEvent(true);
			_source = NpgsqlDataSource.Create(_currentConfig());
			_cancellation = new CancellationTokenSource();
			BUFFER_SIZE = 81920 / sizeof(int);
			buffer = new Queue<LogRecord>(BUFFER_SIZE);
			var options = new BoundedChannelOptions(BUFFER_SIZE)
			{
				//AllowSynchronousContinuations = true,
				//FullMode = BoundedChannelFullMode.Wait,
				SingleReader = true,
				SingleWriter = false
			};
			_logQueue = Channel.CreateBounded<LogRecord>(options);	

			_outputThread ??= new Thread(ProcessQueue)
			{
				IsBackground = true,
				Name = $"Buffered postgre log queue processing thread"
			};
			_outputThread.Start();
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			_scopeProvider ??= new LogTableScopesProvider();
			return _scopeProvider.Push(state);
		}

#if DEV
		int readedCount;
		int writedCount; 
#endif
		public bool IsEnabled(LogLevel logLevel) =>
			logLevel != LogLevel.None;

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			if (_scopeProvider == null || !IsEnabled(logLevel))
				return;

			var logEntry = new LogRecord<TState>(new LogEntry<TState>(logLevel, _contextName, eventId, state, exception, formatter), _scopeProvider.CurrentScope);
			WriteEntry(logEntry);
		}

		private void WriteEntry(LogRecord entry)
		{
			_initialize?.Invoke();
			_slim.WaitOne();
			_logQueue.Writer.TryWrite(entry);
			if (_logQueue.Reader.Count >= BUFFER_SIZE)
				_slim.Reset();

#if DEV
			readedCount++;
#endif
		}

		private static void ThrowLoggingError(params Exception[] exceptions)
		{
			throw new AggregateException(message: "An error occurred while writing to logger(s).", innerExceptions: exceptions);
		}

		public void Flush()
		{
#if DEV
			Console.WriteLine($"Flushing");
#endif
			_cancellation?.Cancel();
			_cancellation?.Dispose();
			_slim?.Dispose();
#if DEV
			Console.WriteLine($"read {readedCount} write {writedCount}");
#endif
		}

		Queue<LogRecord> buffer;
		Queue<LogRecord> buffer2;
		Task currentRead;
		private async void ProcessQueue()
		{
#if DEV
			Console.WriteLine($"{DateTime.UtcNow} read {readedCount} write {writedCount}"); 
#endif			
			try
			{
				while (!_cancellation.IsCancellationRequested)
				{
					if (currentRead == null || currentRead.Status == TaskStatus.RanToCompletion)
						currentRead = ReadToBuffer(_cancellation.Token);

					await currentRead.ConfigureAwait(false);
					if (buffer.Count < 1)
					{
#if DEV
						Console.WriteLine($"{DateTime.UtcNow} read {readedCount} write {writedCount}");
#endif						
						continue;
					}
					else
					{
						buffer2 = buffer;
						buffer = null;
						_slim.Set();
						currentRead = ReadToBuffer(_cancellation.Token);
					}
					var scopes = 
								from item in buffer2
								group item by item.Scope.ToString()
								into patrition
								select new { table = patrition.Key, items = patrition.ToImmutableList() };
						

					using var conn = _source.OpenConnection();
					foreach (var scope in scopes)								
					{
						using var writer = conn.BeginBinaryImport(scope.table);
						using var dbWriter = new BulkWriter(writer);

						foreach (var item in scope.items)
						{
							if (_cancellation.IsCancellationRequested)
								break;

							item.Write(dbWriter, null);
#if DEV
							writedCount++;
#endif
						}
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
				ThrowLoggingError(error);
			}
		}

		int readIsWork;
		private async Task ReadToBuffer(CancellationToken cancel)
		{
			if (Interlocked.Exchange(ref readIsWork, 1) > 0) return;
			if (buffer?.Count == BUFFER_SIZE)
			{
				Interlocked.Decrement(ref readIsWork);
				return;
			}

			ushort elapsed = 0;
			ushort position = 0;
			Queue<LogRecord> innerBuffer = new Queue<LogRecord>(BUFFER_SIZE);			
			do
			{				
				if (_logQueue.Reader.TryRead(out var current))
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
			while (elapsed < WRITE_TIME_THRESHOLD && position < BUFFER_SIZE && !cancel.IsCancellationRequested);
			buffer = innerBuffer;
			currentRead = null;
			Interlocked.Decrement(ref readIsWork);
		}
	}
}


