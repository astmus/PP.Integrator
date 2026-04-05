using static PP.Integrator.Logging.LogTableScopesProvider;

namespace PP.Integrator.Logging;

/// <summary>
/// Базовый класс элемента логирования.
/// </summary>
/// <param name="Scope">Объект контекста (scope), с которым связана запись.</param>
internal abstract record LogRecord(TableScope Scope)
{
	public byte[] ErrorBytes { get; set; }
	public byte[] StateBytes { get; set; }
	/// <summary>
	/// Записывает запись лога через указанный writer.
	/// </summary>
	/// <param name="entryWriter">Компонент, выполняющий запись.</param>
	public abstract void Write(ILogEntryWriter entryWriter);
}

