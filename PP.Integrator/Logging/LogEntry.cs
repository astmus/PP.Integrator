using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging;

/// <summary>
/// Данные одной записи лога.
/// </summary>
/// <typeparam name="TState">Тип состояния, переданного в логгер.</typeparam>
public readonly record struct LogEntry<TState>
{
	/// <summary>
	/// Создает контейнер с данными одной записи журнала.
	/// </summary>
	/// <param name="logLevel">Уровень логирования.</param>
	/// <param name="category">Категория логгера.</param>
	/// <param name="eventId">Идентификатор события.</param>
	/// <param name="state">Состояние записи.</param>
	/// <param name="exception">Исключение, связанное с записью.</param>
	/// <param name="formatter">Функция форматирования сообщения.</param>
	public LogEntry(LogLevel logLevel, string category, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
	{
		Category = category;
		EventId = eventId;
		Exception = exception;
		Formatter = formatter;
		LogLevel = logLevel;
		State = state;
	}

	/// <summary>
	/// Категория логгера.
	/// </summary>
	public string Category { get; }

	/// <summary>
	/// Идентификатор события.
	/// </summary>
	public EventId EventId { get; }

	/// <summary>
	/// Исключение, если оно было передано при логировании.
	/// </summary>
	public Exception? Exception { get; }

	/// <summary>
	/// Делегат для форматирования итогового сообщения.
	/// </summary>
	public Func<TState, Exception?, string> Formatter { get; }

	/// <summary>
	/// Уровень логирования.
	/// </summary>
	public LogLevel LogLevel { get; }

	/// <summary>
	/// Состояние записи.
	/// </summary>
	public TState State { get; }

	/// <summary>
	/// Момент создания записи в UTC.
	/// </summary>
	public DateTimeOffset Timestamp { get; } = DateTimeOffset.UtcNow;
}
