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
			if (_scopeProvider == null || !IsEnabled(logLevel))
				return;

			var logEntry = new LogRecord<TState>(new LogEntry<TState>(logLevel, _contextName, eventId, state, exception, formatter),
				_scopeProvider.CurrentScope);
			_parentLogger.WriteEntry(logEntry);
		}

		public bool IsEnabled(LogLevel logLevel) =>
			logLevel >= (_minimumLevel ?? _parentLogger.DefaultLogLevel);

		public IDisposable BeginScope<TState>(TState state)
		{
			_scopeProvider ??= new LogTableScopesProvider(true);
			if (state is not LogScope scope)
				return _scopeProvider.Push(state);

			_minimumLevel = scope.MinimumLevel;
			return _scopeProvider.Push(scope.Table);
		}
	}
}
