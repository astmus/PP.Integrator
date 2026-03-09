using Microsoft.Extensions.Logging;
using PP.Integrator.Formatters;

namespace PP.Integrator.Logging;

/// <summary>
/// Базовый класс элемента логирования.
/// </summary>
/// <param name="Scope"></param>
public abstract record LogRecord(object Scope)
{
	/// <summary>
	/// Записывает запись лога через указанный writer.
	/// </summary>
	/// <param name="entryWriter"></param>
	/// <param name="textWriter"></param>
	public abstract void Write(ILogEntryWriter entryWriter, TextWriter textWriter);

	internal virtual void Write(BulkWriter writer, object _) => Write((ILogEntryWriter)writer, TextWriter.Null);
}


