using PP.Integrator.Formatters;
using static PP.Integrator.Logging.LogTableScopesProvider;

namespace PP.Integrator.Logging;

/// <summary>
/// Запись лога с конкретным типом полезной нагрузки.
/// </summary>
/// <typeparam name="TEntry">Тип полезной нагрузки записи.</typeparam>
/// <param name="Entry">Данные лог-события.</param>
/// <param name="Scope">Контекст (scope) логирования.</param>
internal record LogRecord<TEntry>(LogEntry<TEntry> Entry, TableScope Scope) : LogRecord(Scope)
{
	/// <summary>
	/// Записывает запись лога через указанный writer.
	/// </summary>
	/// <param name="entryWriter">Компонент, выполняющий запись.</param>
	public override void Write(ILogEntryWriter entryWriter) => entryWriter.Write(Entry, Scope);
}
