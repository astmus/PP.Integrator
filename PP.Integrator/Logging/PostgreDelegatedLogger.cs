using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
	internal sealed class PostgreDelegatedLogger : ILogger
	{
		private readonly string _contextName;
		private readonly PostgreLoggerBase _parentLogger;
		//private readonly LogTableScopesProvider _scopeProvider = new(withDefaultScope: true);

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
				_parentLogger.ScopeProvider.CurrentScope);

			_parentLogger.EnqueueEntry(logEntry);
		}

		public bool IsEnabled(LogLevel logLevel) =>
			_parentLogger.IsEnabled(logLevel);

		public IDisposable BeginScope<TState>(TState state)
		{
			if (state is string tableName)
				return _parentLogger.ScopeProvider.Push(tableName);

			return _parentLogger.ScopeProvider.Push(state.ToString());
		}
	}
}
