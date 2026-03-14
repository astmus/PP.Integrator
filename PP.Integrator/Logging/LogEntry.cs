using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging;

/// <summary>
/// Данные одной записи лога.
/// </summary>
/// <typeparam name="TState"></typeparam>
public readonly struct LogEntry<TState>
{
	public LogEntry(LogLevel logLevel, string category, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
	{
		Category = category;
		EventId = eventId;
		Exception = exception;
		Formatter = formatter;
		LogLevel = logLevel;
		State = state;
	}

	public string Category { get; }

	public EventId EventId { get; }

	public Exception? Exception { get; }

	public Func<TState, Exception?, string> Formatter { get; }

	public LogLevel LogLevel { get; }

	public TState State { get; }

	public DateTimeOffset Timestamp { get; } = DateTimeOffset.UtcNow;
}

public readonly record struct LogEntry(LogLevel logLevel, string category, EventId eventId, ReadOnlyMemory<byte> state, ReadOnlyMemory<byte>? exception);
