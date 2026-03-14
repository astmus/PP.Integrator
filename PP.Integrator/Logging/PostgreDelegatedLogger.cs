using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
	internal sealed class PostgreDelegatedLogger : ILogger
	{
		private readonly string _contextName;
		private readonly PostgreLoggerBase _parentLogger;
		private readonly LogTableScopesProvider _scopeProvider = new(withDefaultScope: true);

		public PostgreDelegatedLogger(string contextName, PostgreLoggerBase parentLogger)
		{
			_contextName = contextName;
			_parentLogger = parentLogger;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			if (!IsEnabled(logLevel))
				return;

			var logEntry = new LogRecord<TState>(new LogEntry<TState>(logLevel, _contextName, eventId, state, exception, formatter),
				_scopeProvider.CurrentScope);
			_parentLogger.WriteEntry(logEntry);
		}

		public bool IsEnabled(LogLevel logLevel) =>
			logLevel != LogLevel.None && logLevel >= _parentLogger.DefaultLogLevel;

		public IDisposable BeginScope<TState>(TState state)
		{
			if (state is LogScope scope)
				return _scopeProvider.Push(scope.Table);

			if (state is string tableName)
				return _scopeProvider.Push(tableName);

			return _scopeProvider.Push(state);
		}
	}
}
