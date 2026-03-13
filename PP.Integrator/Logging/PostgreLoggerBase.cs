using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace PP.Integrator.Logging
{
	internal abstract class PostgreLoggerBase : ILogger, IDisposable
	{
		private readonly string _contextName;
		protected readonly NpgsqlDataSource DataSource;
		private readonly object _initLock = new();
		private Func<bool> _ensureInitializedDelegate;
		private bool _initialized;
		private int _disposed;
		internal LogTableScopesProvider? _scopeProvider;
		protected long _lastErrorLogTicksUtc;

		protected PostgreLoggerBase(
			string contextName,
			NpgsqlDataSource dataSource,
			PostgreLoggerProviderOptions options,
			LogLevel defaultLogLevel)
		{
			_contextName = contextName;
			DataSource = dataSource;
			Options = options;
			DefaultLogLevel = defaultLogLevel;
			_ensureInitializedDelegate = EnsureInitialized;
		}

		protected PostgreLoggerProviderOptions Options { get; }
		protected int MaxBufferItemsCount => Options.MaxBufferItemsCount;
		protected int AutoFlushDuration => Options.AutoFlushDuration;
		protected int WriteRetryCount => Options.WriteRetryCount;
		internal LogLevel DefaultLogLevel { get; }

		public IDisposable BeginScope<TState>(TState state)
		{
			_scopeProvider ??= new LogTableScopesProvider();
			return _scopeProvider.Push(state);
		}

		public bool IsEnabled(LogLevel logLevel) =>
			logLevel != LogLevel.None && logLevel >= DefaultLogLevel;

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			if (_scopeProvider == null || !IsEnabled(logLevel))
				return;

			var entry = new LogRecord<TState>(
				new LogEntry<TState>(logLevel, _contextName, eventId, state, exception, formatter),
				_scopeProvider.CurrentScope);
			WriteEntry(entry);
		}

		internal void WriteEntry(LogRecord entry)
		{
			if (!_ensureInitializedDelegate())
				return;

			EnqueueEntry(entry);
		}

		private bool EnsureInitialized()
		{
			if (Volatile.Read(ref _disposed) == 1)
				return false;

			lock (_initLock)
			{
				if (_initialized || Volatile.Read(ref _disposed) == 1)
				{
					_ensureInitializedDelegate = IsAlive;
					return IsAlive();
				}

				InitializeCore();
				_initialized = true;
				_ensureInitializedDelegate = IsAlive;
				return IsAlive();
			}
		}

		private bool IsAlive() =>
			!(!_initialized || Volatile.Read(ref _disposed) == 1);

		protected void ReportLoggingError(string loggerName, Exception error)
		{
			var nowTicks = DateTime.UtcNow.Ticks;
			var prevTicks = Interlocked.Read(ref _lastErrorLogTicksUtc);
			if (nowTicks - prevTicks < TimeSpan.FromSeconds(5).Ticks)
				return;

			Interlocked.Exchange(ref _lastErrorLogTicksUtc, nowTicks);
			Console.Error.WriteLine($"[{loggerName}] {error.GetType().Name}: {error.Message}");
		}

		protected void ExecuteWithRetry(string loggerName, string table, Action operation)
		{
			Exception? lastError = null;
			for (var attempt = 0; attempt <= WriteRetryCount; attempt++)
			{
				try
				{
					operation();
					return;
				}
				catch (Exception ex) when (IsTransientWriteError(ex) && attempt < WriteRetryCount)
				{
					lastError = ex;
					ReportTransientWriteError(loggerName, ex, table, attempt + 1, WriteRetryCount);
					Thread.Sleep((attempt + 1) * 100);
				}
				catch (Exception ex)
				{
					lastError = ex;
					break;
				}
			}

			throw lastError ?? new InvalidOperationException($"[{loggerName}] Retry pipeline terminated without explicit error.");
		}

		protected virtual bool IsTransientWriteError(Exception ex) =>
			ex is NpgsqlException or TimeoutException or IOException;

		protected static void ReportTransientWriteError(string loggerName, Exception error, string table, int attempt, int maxRetries)
		{
			Console.Error.WriteLine(
				$"[{loggerName}][TransientWriteError] table='{table}', attempt={attempt}/{maxRetries}, type={error.GetType().FullName}, message={error.Message}");
			if (error.InnerException != null)
			{
				Console.Error.WriteLine(
					$"[{loggerName}][TransientWriteError][Inner] type={error.InnerException.GetType().FullName}, message={error.InnerException.Message}");
			}
		}

		protected static string BuildCopyCommand(string schemaName, string tableName) =>
			$"COPY  {schemaName}.{tableName} ({string.Join(',', LogTableScopesProvider.TableScope.Columns())}) FROM STDIN (FORMAT BINARY)";

		protected static (string schemaName, string tableName) ResolveDestination(string? qualifiedTableName)
		{
			if (string.IsNullOrWhiteSpace(qualifiedTableName))
				return ("logs", "log");

			var dotIndex = qualifiedTableName.IndexOf('.');
			if (dotIndex <= 0 || dotIndex >= qualifiedTableName.Length - 1)
				return ("logs", NormalizeDbIdentifier(qualifiedTableName));

			var schemaName = NormalizeDbIdentifier(qualifiedTableName[..dotIndex]);
			var tableName = NormalizeDbIdentifier(qualifiedTableName[(dotIndex + 1)..]);
			return (schemaName, tableName);
		}

		private static string NormalizeDbIdentifier(string rawName)
		{
			if (string.IsNullOrWhiteSpace(rawName))
				return "log";

			var source = rawName.Trim().ToLowerInvariant();
			var builder = new StringBuilder(source.Length);
			for (var i = 0; i < source.Length; i++)
			{
				var ch = source[i];
				builder.Append(ch is >= 'a' and <= 'z' or >= '0' and <= '9' or '_' ? ch : '_');
			}

			var prepared = string.Join('_', builder.ToString().Split('_', StringSplitOptions.RemoveEmptyEntries));
			return string.IsNullOrWhiteSpace(prepared) ? "log" : prepared;
		}

		protected bool TryDispose() => Interlocked.Exchange(ref _disposed, 1) == 0;
		protected bool IsDisposed => Volatile.Read(ref _disposed) == 1;

		protected abstract void InitializeCore();
		protected abstract void EnqueueEntry(LogRecord entry);
		public abstract void Flush();
		public void Dispose() => Flush();
	}
}
