using PP.Integrator.Formatters;

namespace PP.Integrator.Logging;

/// <summary>
/// Запись лога с конкретным типом полезной нагрузки.
/// </summary>
/// <typeparam name="TEntry"></typeparam>
/// <param name="Entry"></param>
/// <param name="Scope"></param>
public record LogRecord<TEntry>(LogEntry<TEntry> Entry, object Scope) : LogRecord(Scope)
{
	/// <summary>
	/// Записывает запись лога через указанный writer.
	/// </summary>
	/// <param name="entryWriter"></param>
	/// <param name="textWriter"></param>
	public override void Write(ILogEntryWriter entryWriter, TextWriter textWriter) => entryWriter.Write(Entry, textWriter, Scope);
}
