using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
	internal sealed partial class PostgreLogger
	{
		internal record DelegatedLogger(string contextName, PostgreLogger parentLogger) : ILogger
		{
			LogTableScopesProvider _scopeProvider;
			LogLevel? minimumLevel = LogLevel.Trace;

			public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
			{
				if (_scopeProvider == null || !IsEnabled(logLevel))
					return;

				var logEntry = new LogRecord<TState>(new LogEntry<TState>(logLevel, contextName, eventId, state, exception, formatter), _scopeProvider.CurrentScope);
				parentLogger.WriteEntry(logEntry);
			}

			public bool IsEnabled(LogLevel logLevel) =>
				logLevel >= minimumLevel;

			public IDisposable BeginScope<TState>(TState state)
			{
				_scopeProvider ??= new LogTableScopesProvider(true);
				if (state is not LogScope scope)
					return _scopeProvider.Push(state);

				minimumLevel = scope.MinimumLevel;
				return _scopeProvider.Push(scope.Table);
			}
		}
	}
}


