using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
	internal sealed class PostgreDelegatedLogger : ILogger
	{
		private readonly string _contextName;
		private readonly PostgreLoggerBase _parentLogger;
		private LogTableScopesProvider? _scopeProvider;
		private LogLevel? _minimumLevel;

		public PostgreDelegatedLogger(string contextName, PostgreLoggerBase parentLogger)
		{
			_contextName = contextName;
			_parentLogger = parentLogger;
			_minimumLevel = parentLogger.DefaultLogLevel;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			if (!IsEnabled(logLevel))
				return;

			_scopeProvider ??= _parentLogger._scopeProvider;
			var logEntry = new LogRecord<TState>(new LogEntry<TState>(logLevel, _contextName, eventId, state, exception, formatter),
				_scopeProvider.CurrentScope);
			_parentLogger.WriteEntry(logEntry);
		}

		public bool IsEnabled(LogLevel logLevel) =>
			logLevel != LogLevel.None && logLevel >= (_minimumLevel ?? _parentLogger.DefaultLogLevel);

		public IDisposable BeginScope<TState>(TState state)
		{
			_scopeProvider ??= new LogTableScopesProvider(true);
			if (state is not LogScope scope)
				return _scopeProvider.Push(state);

			var previousMinimum = _minimumLevel;
			_minimumLevel = scope.MinimumLevel;
			return new MinimumLevelScope(this, _scopeProvider.Push(scope.Table), previousMinimum);
		}

		private sealed class MinimumLevelScope : IDisposable
		{
			private readonly PostgreDelegatedLogger _logger;
			private readonly IDisposable _inner;
			private readonly LogLevel? _previousMinimumLevel;
			private bool _disposed;

			public MinimumLevelScope(PostgreDelegatedLogger logger, IDisposable inner, LogLevel? previousMinimumLevel)
			{
				_logger = logger;
				_inner = inner;
				_previousMinimumLevel = previousMinimumLevel;
			}

			public void Dispose()
			{
				if (_disposed)
					return;

				_inner.Dispose();
				_logger._minimumLevel = _previousMinimumLevel;
				_disposed = true;
			}
		}
	}
}
