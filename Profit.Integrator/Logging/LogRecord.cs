using Microsoft.Extensions.Logging;

namespace Profit.Integrator.Logging
{
	public abstract record ILogRecord(object Scope)
	{
		public abstract void Write(ILogEntryWriter entryWriter, TextWriter textWriter);
	}

	public record LogRecord<TRecord>(LogEntry<TRecord> Record, object Scope) : ILogRecord(Scope)
	{
		public override void Write(ILogEntryWriter entryWriter, TextWriter textWriter)
		{
			entryWriter.Write(Record, textWriter, Scope);
		}
	}

	public readonly struct LogEntry<TState>
	{
		public LogEntry(LogLevel logLevel, string category, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			LogLevel = logLevel;
			Category = category;
			EventId = eventId;
			State = state;
			Exception = exception;
			Formatter = formatter;
		}

		public LogLevel LogLevel { get; }
		public string Category { get; }
		public EventId EventId { get; }
		public TState State { get; }
		public Exception? Exception { get; }
		public DateTimeOffset Timestamp { get; } = DateTimeOffset.UtcNow;
		public Func<TState, Exception?, string> Formatter { get; }
	}
}


