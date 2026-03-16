using Microsoft.Extensions.Logging;
using Npgsql;

namespace PP.Integrator.Logging
{
	internal abstract class PostgreLoggerBase : ILogger, IDisposable
	{
		private readonly string _contextName;
		protected readonly NpgsqlDataSource DataSource;
		private readonly object _initLock = new();
		private static readonly object EnsuredTablesSync = new();
		private static readonly HashSet<string> EnsuredTables = new(StringComparer.Ordinal);
		private Func<bool> _ensureInitializedDelegate;
		private bool _initialized;
		private int _disposed;

		protected long _lastErrorLogTicksUtc;

		internal LogTableScopesProvider ScopeProvider;

		protected PostgreLoggerBase(string contextName, IPostgreLoggingDataSourceAccessor dataSourceAccessor, PostgreLoggerProviderOptions options)
		{
			_contextName = contextName;
			DataSource = dataSourceAccessor.DataSource;
			Options = options;
			ScopeProvider = new LogTableScopesProvider(withDefaultScope: true);
			_ensureInitializedDelegate = EnsureInitialized;
		}

		protected PostgreLoggerProviderOptions Options { get; }
		protected int MaxBufferItemsCount => Options.MaxBufferItemsCount;
		protected int AutoFlushDuration => Options.AutoFlushDuration;
		protected int WriteRetryCount => Options.WriteRetryCount;

		public IDisposable BeginScope<TState>(TState state) =>
			ScopeProvider.Push(state);

		public bool IsEnabled(LogLevel logLevel)
			=> logLevel != LogLevel.None;

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			if (!IsEnabled(logLevel))
				return;

			var entry = new LogRecord<TState>(
				new LogEntry<TState>(logLevel, _contextName, eventId, state, exception, formatter),
				ScopeProvider.CurrentScope);

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
			_initialized && Volatile.Read(ref _disposed) != 1;

		protected void ReportLoggingError(string loggerName, Exception error)
		{
			var nowTicks = DateTime.UtcNow.Ticks;
			var prevTicks = Interlocked.Read(ref _lastErrorLogTicksUtc);
			if (nowTicks - prevTicks < TimeSpan.FromSeconds(5).Ticks)
				return;

			Interlocked.Exchange(ref _lastErrorLogTicksUtc, nowTicks);
			Console.Error.WriteLine($"[{loggerName}] {error.GetType().Name}: {error.Message}");
		}

		protected virtual bool IsTransientWriteError(Exception ex) =>
			ex is NpgsqlException or TimeoutException or IOException;

		protected static void ReportTransientWriteError(string loggerName, Exception error, string table, int attempt, int maxRetries)
		{
			Console.Error.WriteLine(
				$"[{loggerName}][TransientWriteError] table='{table}', attempt={attempt}/{maxRetries}, type={error.GetType().FullName}, message={error.Message}");

			if (error.InnerException != null)
				Console.Error.WriteLine(
					$"[{loggerName}][TransientWriteError][Inner] type={error.InnerException.GetType().FullName}, message={error.InnerException.Message}");
		}

		protected void EnsureTableExists(string qualifiedTableName)
		{
			lock (EnsuredTablesSync)
			{
				if (EnsuredTables.Contains(qualifiedTableName))
					return;

				var indexName = qualifiedTableName.Replace('.', '_') + "_timestamp_brin_idx";
				using var command = DataSource.CreateCommand(
					$"CREATE SCHEMA IF NOT EXISTS logs; " +
					$"CREATE unlogged TABLE IF NOT EXISTS {qualifiedTableName} " +
					"(timestamp TIMESTAMPTZ, " +
					"loglevel text, " +
					"category TEXT NOT NULL, " +
					"message text, " +
					"eventid integer, " +
					"exception JSONB, " +
					"originalformat text, " +
					"state JSONB); " +
					$"CREATE INDEX IF NOT EXISTS {indexName} " +
					$"ON {qualifiedTableName} USING brin (timestamp);");
				command.ExecuteNonQuery();
				EnsuredTables.Add(qualifiedTableName);
			}
		}

		protected bool TryDispose() => Interlocked.Exchange(ref _disposed, 1) == 0;
		protected bool IsDisposed => Volatile.Read(ref _disposed) == 1;

		protected abstract void InitializeCore();
		protected abstract void EnqueueEntry(LogRecord entry);
		public abstract void Flush();
		public void Dispose() => Flush();
	}
}
