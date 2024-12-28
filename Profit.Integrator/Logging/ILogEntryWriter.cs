using Microsoft.Extensions.Logging;

namespace Profit.Integrator.Logging
{
	public interface ILogEntryWriter
    {
        void Write<TState>(in LogEntry<TState> logEntry, TextWriter textWriter, object scope);
    }
}


