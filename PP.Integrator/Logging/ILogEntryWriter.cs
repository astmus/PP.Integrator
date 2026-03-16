using Npgsql;

namespace PP.Integrator.Logging
{
	/// <summary>
	/// Интерфейс записи лог-события в целевой поток.
	/// </summary>
	public interface ILogEntryWriter
	{
		/// <summary>
		/// Записывает одну запись лога в указанный <see cref="TextWriter"/>.
		/// </summary>
		/// <typeparam name="TState">Тип состояния записи.</typeparam>
		/// <param name="logEntry">Данные лог-события.</param>
		/// <param name="textWriter">Поток для вывода сериализованных данных.</param>
		/// <param name="scope">Текущий scope логирования.</param>
		void Write<TState>(in LogEntry<TState> logEntry, TextWriter textWriter, object scope);
	}
}
