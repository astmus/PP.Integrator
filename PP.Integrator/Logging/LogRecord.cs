using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
	/// <summary>
	/// Базовый класс элемента логирования
	/// </summary>
	/// <param name="Scope"></param>
	public abstract record LogRecord(object Scope)
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entryWriter"></param>
		/// <param name="textWriter"></param>
		public abstract void Write(ILogEntryWriter entryWriter, TextWriter textWriter);
	}

	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	/// <typeparam name="TEntry"></typeparam>
	/// <param name="Entry"></param>
	/// <param name="Scope"></param>
	public record LogRecord<TEntry>(LogEntry<TEntry> Entry, object Scope) : LogRecord(Scope)
	{
		/// <summary>
		/// Записать LogEntry при помощи <paramref name="entryWriter"/>
		/// </summary>
		/// <param name="entryWriter"></param>
		/// <param name="textWriter"></param>
		public override void Write(ILogEntryWriter entryWriter, TextWriter textWriter)
		{
			entryWriter.Write(Entry, textWriter, Scope);
		}
	}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	/// <summary>
	/// Класс записи в логе
	/// </summary>
	/// <typeparam name="TState"></typeparam>
	public readonly struct LogEntry<TState>
	{
		public LogEntry(LogLevel logLevel, string category, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			LogLevel = logLevel;
			Category = category;
			EventId = eventId;
			State = state;
			Exception = exception;
			Formatter = formatter;
		}

		public LogLevel LogLevel { get; }
		public string Category { get; }
		public EventId EventId { get; }
		public TState State { get; }
		public Exception? Exception { get; }
		public DateTimeOffset Timestamp { get; } = DateTimeOffset.UtcNow;
		public Func<TState, Exception?, string> Formatter { get; }
	}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}


