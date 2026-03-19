using PP.Integrator.Formatters;

namespace PP.Integrator.Logging;

/// <summary>
/// Запись лога с конкретным типом полезной нагрузки.
/// </summary>
/// <typeparam name="TEntry">Тип полезной нагрузки записи.</typeparam>
/// <param name="Entry">Данные лог-события.</param>
/// <param name="Scope">Контекст (scope) логирования.</param>
public record LogRecord<TEntry>(LogEntry<TEntry> Entry, object Scope) : LogRecord(Scope)
{
	/// <summary>
	/// Записывает запись лога через указанный writer.
	/// </summary>
	/// <param name="entryWriter">Компонент, выполняющий запись.</param>
	public override void Write(ILogEntryWriter entryWriter) => entryWriter.Write(Entry, Scope);
}
