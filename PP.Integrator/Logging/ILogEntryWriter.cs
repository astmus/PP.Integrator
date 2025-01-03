using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
	public interface ILogEntryWriter
    {
        void Write<TState>(in LogEntry<TState> logEntry, TextWriter textWriter, object scope);
    }
}


