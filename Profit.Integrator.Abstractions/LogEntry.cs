using Microsoft.Extensions.Logging;

namespace Profit.Integrator
{
    public abstract record LogRecord(Action<ILogEntryWriter, TextWriter> write);
    public record LogRecord<TRecord>(LogEntry<TRecord> Record) : LogRecord((fr, wr) => fr.Write(Record, wr));

    public readonly struct LogEntry<TState>
    {
        public LogEntry(LogLevel logLevel, string category, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter, IExternalScopeProvider provider)
        {
            LogLevel = logLevel;
            Category = category;
            EventId = eventId;
            State = state;
            Exception = exception;
            Formatter = formatter;
            Provider = provider;
        }

        public LogLevel LogLevel { get; }
        public string Category { get; }
        public EventId EventId { get; }
        public TState State { get; }
        public Exception? Exception { get; }
        public Func<TState, Exception?, string> Formatter { get; }
        public IExternalScopeProvider Provider { get; }
    }
}


