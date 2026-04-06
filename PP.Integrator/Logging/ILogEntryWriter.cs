using Npgsql;

namespace PP.Integrator.Logging
{
	/// <summary>
	/// Интерфейс записи лог-события в целевой поток.
	/// </summary>
	internal interface ILogEntryWriter
	{
		/// <summary>
		/// Записывает одну запись лога
		/// </summary>
		/// <typeparam name="TState">Тип состояния записи.</typeparam>
		/// <param name="record">Данные лог-события.</param>
		/// <param name="scope">Текущий scope логирования.</param>
		void Write<TState>(in LogRecord<TState> record, object scope);
	}
}
