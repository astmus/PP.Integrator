using Microsoft.Extensions.Logging;
using PP.Integrator.Formatters;

namespace PP.Integrator.Logging;

/// <summary>
/// Базовый класс элемента логирования.
/// </summary>
/// <param name="Scope">Объект контекста (scope), с которым связана запись.</param>
public abstract record LogRecord(object Scope)
{
	/// <summary>
	/// Записывает запись лога через указанный writer.
	/// </summary>
	/// <param name="entryWriter">Компонент, выполняющий запись.</param>
	public abstract void Write(ILogEntryWriter entryWriter);
}

