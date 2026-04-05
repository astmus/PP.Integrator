using Microsoft.Extensions.Logging;
using PP.Integrator.Formatters;
using PP.Integrator.Logging;

namespace PP.Tests;

public class EntryWriterTests
{
	[Fact]
	public void Write_StructuredState_MustMoveOriginalFormatIntoSeparateColumn()
	{
		var writer = new SpyEntryWriter();
		var state = new KeyValuePair<string, object?>[]
		{
			new("UserId", 42),
			new("{OriginalFormat}", "User {UserId}")
		};
		var entry = new LogEntry<IReadOnlyList<KeyValuePair<string, object?>>>(
			LogLevel.Information,
			"Tests.Writer",
			new EventId(7, "evt"),
			state,
			null,
			static (currentState, _) => $"User {currentState[0].Value}");

		writer.Write(entry, "logs.test_log");

		Assert.Equal("User {UserId}", writer.WrittenFormat);
		var writtenState = Assert.IsType<KeyValuePair<string, object?>[]>(writer.WrittenState);
		var item = Assert.Single(writtenState);
		Assert.Equal("UserId", item.Key);
		Assert.Equal(42, item.Value);
	}

	[Fact]
	public void Write_StructuredStateWithoutOriginalFormat_MustKeepOriginalInstance()
	{
		var writer = new SpyEntryWriter();
		IReadOnlyList<KeyValuePair<string, object?>> state = new List<KeyValuePair<string, object?>>
		{
			new("UserId", 42)
		};
		var entry = new LogEntry<IReadOnlyList<KeyValuePair<string, object?>>>(
			LogLevel.Information,
			"Tests.Writer",
			new EventId(8, "evt"),
			state,
			null,
			static (currentState, _) => $"User {currentState[0].Value}");

		writer.Write(entry, "logs.test_log");

		Assert.Null(writer.WrittenFormat);
		Assert.Same(state, writer.WrittenState);
	}

	private sealed class SpyEntryWriter : EntryWriter
	{
		public string? WrittenContext { get; private set; }
		public int WrittenEventId { get; private set; }
		public Exception? WrittenException { get; private set; }
		public string? WrittenFormat { get; private set; }
		public LogLevel WrittenLogLevel { get; private set; }
		public string? WrittenMessage { get; private set; }
		public object? WrittenState { get; private set; }
		public DateTimeOffset WrittenTimestamp { get; private set; }

		protected override void WriteContext(string context) => WrittenContext = context;

		protected override void WriteEventId(in EventId eventId) => WrittenEventId = eventId.Id;

		protected override void WriteException(Exception? exception) => WrittenException = exception;

		protected override void WriteFormat(string? messageFormat) => WrittenFormat = messageFormat;

		protected override void WriteLogLevel(in LogLevel logLevel) => WrittenLogLevel = logLevel;

		protected override void WriteMessage(string? message) => WrittenMessage = message;

		protected override void WriteState(object? state) => WrittenState = state;

		protected override void WriteTimestamp(in DateTimeOffset timestamp) => WrittenTimestamp = timestamp;
	}
}
