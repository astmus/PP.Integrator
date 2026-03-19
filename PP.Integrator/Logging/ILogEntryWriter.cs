using Npgsql;

namespace PP.Integrator.Logging
{
	/// <summary>
	/// Интерфейс записи лог-события в целевой поток.
	/// </summary>
	public interface ILogEntryWriter
	{
		/// <summary>
		/// Записывает одну запись лога
		/// </summary>
		/// <typeparam name="TState">Тип состояния записи.</typeparam>
		/// <param name="logEntry">Данные лог-события.</param>
		/// <param name="scope">Текущий scope логирования.</param>
		void Write<TState>(in LogEntry<TState> logEntry, object scope);
	}
}
