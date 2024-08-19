namespace Profit.Integrator
{
    public interface ILogEntryWriter
    {
        void Write<TState>(in LogEntry<TState> logEntry, TextWriter textWriter);
    }
}


