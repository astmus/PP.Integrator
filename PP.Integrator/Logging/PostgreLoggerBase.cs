using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace PP.Integrator.Logging
{
	internal abstract class PostgreLoggerBase : IDisposable
	{
		protected readonly NpgsqlDataSource DataSource;
		private readonly object _initLock = new();
		private static readonly object EnsuredTablesSync = new();
		private static readonly HashSet<string> EnsuredTables = new(StringComparer.Ordinal);
		private Func<bool> _ensureInitializedDelegate;
		private bool _initialized;
		private int _disposed;

		protected long _lastErrorLogTicksUtc;
		protected readonly PostgreLoggerProviderOptions Options;

		internal readonly LogTableScopesProvider ScopeProvider;

		protected PostgreLoggerBase(IPostgreLoggingDataSourceAccessor dataSourceAccessor, PostgreLoggerProviderOptions options)
		{
			DataSource = dataSourceAccessor.DataSource;
			Options = options;
			ScopeProvider = new LogTableScopesProvider(withDefaultScope: true);
			_ensureInitializedDelegate = EnsureInitialized;
		}

		protected int MaxBufferItemsCount => Options.MaxBufferItemsCount;
		protected int AutoFlushDuration => Options.AutoFlushDuration;
		protected int WriteRetryCount => Options.WriteRetryCount;

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
		public bool IsEnabled(LogLevel logLevel) =>
			logLevel != LogLevel.None;

		internal void WriteEntry(LogRecord entry)
		{
			if (!EnsureCanWrite())
				return;

			EnqueueEntry(entry);
		}

		private bool EnsureCanWrite()
		{
			if (!_ensureInitializedDelegate())
				return false;

			return true;
		}

		private bool EnsureInitialized()
		{
			if (IsDisposed)
				return false;

			lock (_initLock)
			{
				if (!_initialized && !IsDisposed)
				{
					InitializeCore();
					_initialized = true;
				}

				_ensureInitializedDelegate = IsAlive;
				return IsAlive();
			}
		}

		private bool IsAlive() =>
			_initialized && Volatile.Read(ref _disposed) != 1;

		protected void ReportLoggingError(Exception error, string message = default, [CallerMemberName] string loggerName = default)
		{
#if DEBUG
			var nowTicks = DateTime.UtcNow.Ticks;
			var prevTicks = Interlocked.Read(ref _lastErrorLogTicksUtc);
			if (nowTicks - prevTicks < TimeSpan.FromSeconds(5).Ticks)
				return;

			Interlocked.Exchange(ref _lastErrorLogTicksUtc, nowTicks);
			Console.Error.WriteLine($"[{loggerName}] {error.GetType().Name}: {error.Message} {message}");

			if (error.InnerException is Exception e)
				ReportLoggingError(e, message, loggerName);
#endif
		}

		protected virtual bool IsTransientWriteError(Exception ex) =>
			ex is NpgsqlException or TimeoutException or IOException;

		protected static void EnsureTableExists(NpgsqlConnection connection, string qualifiedTableName)
		{
			lock (EnsuredTablesSync)
			{
				if (EnsuredTables.Contains(qualifiedTableName))
					return;

				var indexName = qualifiedTableName.Replace('.', '_') + "_timestamp_brin_idx";
				using NpgsqlCommand cmd = connection.CreateCommand();
				cmd.CommandText =
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
					$"ON {qualifiedTableName} USING brin (timestamp);";
				cmd.ExecuteNonQuery();
				EnsuredTables.Add(qualifiedTableName);
			}
		}

		protected bool TryBeginDispose() => Interlocked.Exchange(ref _disposed, 1) == 0;
		protected bool IsDisposed => Volatile.Read(ref _disposed) == 1;

		protected abstract void InitializeCore();
		protected abstract void EnqueueEntry(LogRecord entry);
		protected abstract void FlushCore();
		protected virtual void DisposeCore(bool disposing) { }

		public void Flush()
		{
			if (IsDisposed)
				return;

			FlushCore();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!TryBeginDispose() || !disposing)
				return;

			try
			{
				FlushCore();
			}
			catch (Exception ex)
			{
				ReportLoggingError(ex);
			}
			finally
			{
				try
				{
					DisposeCore(disposing);
				}
				catch (Exception ex)
				{
					ReportLoggingError(ex);
				}
			}
		}
	}
}
