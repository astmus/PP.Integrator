using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using Npgsql;
using Profit.Integrator.Formatters;

namespace Profit.Integrator.Logging
{
	internal sealed class PostgreLogger : ILogger
	{
		private readonly string _name;
		private readonly Func<NpgsqlConnectionStringBuilder> _currentConfig;
		private LogTableScopesProvider ScopeProvider;
		private Channel<ILogRecord> _logQueue;
		private ConcurrentQueue<ILogRecord> _logQueue2;
		private NpgsqlDataSource _source;
		private Thread _outputThread;
		private Action? _initialize;
		private CancellationTokenSource _cancellation;
		private ManualResetEvent _slim;
		private const int bufferSize = 4096;
		private const ushort timeThreshold = 4096;
		public PostgreLogger(string name, Func<NpgsqlConnectionStringBuilder> getCurrentConfig)
		{
			_name = name;
			_currentConfig = getCurrentConfig;
			_initialize = Initialize;
		}

		void Initialize()
		{
			_initialize = null;
			_slim = new ManualResetEvent(true);
			_source = NpgsqlDataSource.Create(_currentConfig());
			_cancellation = new CancellationTokenSource();
			var options = new BoundedChannelOptions(bufferSize)
			{
				//AllowSynchronousContinuations = true,
				//FullMode = BoundedChannelFullMode.Wait,
				SingleReader = true,
				SingleWriter = false
			};
			_logQueue = Channel.CreateBounded<ILogRecord>(options);	

			_outputThread ??= new Thread(ProcessQueue)
			{
				IsBackground = true,
				Name = $"Buffered log queue processing thread {_name}"
			};
			_outputThread.Start();
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			ScopeProvider ??= new LogTableScopesProvider();
			return ScopeProvider.Push(state);
		}

#if DEBUG
		int count = 0;
		int countw = 0; 
#endif
		public bool IsEnabled(LogLevel logLevel) =>
			logLevel != LogLevel.None;

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			if (ScopeProvider == null)
				return;
			//ArgumentNullException.ThrowIfNull(ScopeProvider, "log table scope");
			if (!IsEnabled(logLevel))
				return;

			_initialize?.Invoke();
			_slim.WaitOne();
			_logQueue.Writer.TryWrite(new LogRecord<TState>(new LogEntry<TState>(logLevel, _name, eventId, state, exception, formatter), ScopeProvider.CurrentScope));
			if (_logQueue.Reader.Count >= bufferSize)
				_slim.Reset();
#if DEBUG
				count++;
#endif
		}

		private static void ThrowLoggingError(params Exception[] exceptions)
		{
			throw new AggregateException(message: "An error occurred while writing to logger(s).", innerExceptions: exceptions);
		}

		public void Flush()
		{
			Console.WriteLine($"Flushing");
			_cancellation?.Cancel();
			_cancellation?.Dispose();
			_slim?.Dispose();
#if DEBUG
			Console.WriteLine($"read {count} write {countw}");
#endif
		}

		Queue<ILogRecord> buffer = new Queue<ILogRecord>(bufferSize);
		Queue<ILogRecord> buffer2;
		Task currentRead;
		private async void ProcessQueue()
		{
#if DEBUG
			Console.WriteLine($"{DateTime.UtcNow} read {count} write {countw}"); 
#endif			
			try
			{
				while (!_cancellation.IsCancellationRequested)
				{
					if (currentRead == null || currentRead.Status == TaskStatus.RanToCompletion)
						currentRead = ReadToBuffer(_cancellation.Token);
					await currentRead;
					if (buffer.Count < 1)
					{
#if DEBUG
						Console.WriteLine($"{DateTime.UtcNow} read {count} write {countw}");
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

					using var conn = _source.OpenConnection();
					using var writer = conn.BeginBinaryImport(buffer2.First().Scope.ToString());
					using var _dbWriter = new BulkWriter(writer);

					while (buffer2.Any() && !_cancellation.IsCancellationRequested)
					{
						buffer2.Dequeue().Write(_dbWriter, null);
#if DEBUG
						countw++; 
#endif
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
			if (buffer?.Count == bufferSize)
			{
				Interlocked.Decrement(ref readIsWork);
				return;
			}

			ushort elapsed = 0;
			ushort pos = 0;
			Queue<ILogRecord> innerBuffer = new Queue<ILogRecord>(bufferSize);			
			do
			{				
				if (_logQueue.Reader.TryRead(out var current))
				{
					innerBuffer.Enqueue(current);
					pos++;
				}
				else
				{
					await Task.Delay(128, cancel);
					elapsed += 128;
				}
			}
			while (elapsed < timeThreshold && pos < bufferSize && !cancel.IsCancellationRequested);
			buffer = innerBuffer;
			currentRead = null;
			Interlocked.Decrement(ref readIsWork);
		}
	}
}


