using Microsoft.Extensions.Logging;
using PP.Integrator.Logging;

namespace PP.Integrator.Formatters;

internal abstract class EntryWriter : ILogEntryWriter
{
	private const string OriginalFormatKey = "{OriginalFormat}";

	public virtual void OnAfterEntryWrite() { }

	public virtual void OnBeforeEntryWrite() { }

	public void Write<TState>(in LogEntry<TState> logEntry, TextWriter textWriter, object scope)
	{
		OnBeforeEntryWrite();
		var message = logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception) ?? logEntry.State?.ToString();
		WriteInternal(message, logEntry.LogLevel, logEntry.Category, logEntry.EventId.Id, logEntry.Exception, logEntry.State, logEntry.Timestamp);
		OnAfterEntryWrite();
	}

	private static object PrepareStatePayload(IReadOnlyList<KeyValuePair<string, object?>> structuredState, out string? originalFormat)
	{
		originalFormat = null;

		var originalFormatIndex = -1;
		for (var i = 0; i < structuredState.Count; i++)
		{
			var item = structuredState[i];
			if (!string.Equals(item.Key, OriginalFormatKey, StringComparison.Ordinal))
				continue;

			originalFormatIndex = i;
			originalFormat = item.Value?.ToString();
			break;
		}

		if (originalFormatIndex < 0)
			return structuredState;
		if (structuredState.Count == 1)
			return Array.Empty<KeyValuePair<string, object?>>();

		var filteredState = new KeyValuePair<string, object?>[structuredState.Count - 1];
		var writeIndex = 0;
		for (var i = 0; i < structuredState.Count; i++)
		{
			if (i == originalFormatIndex)
				continue;

			filteredState[writeIndex++] = structuredState[i];
		}

		return filteredState;
	}

	protected void WriteInternal(string? message, in LogLevel logLevel, string context, in int eventId, Exception? exception, object? state, in DateTimeOffset stamp)
	{
		var originalFormat = default(string);
		var statePayload = state;
		if (state is IReadOnlyList<KeyValuePair<string, object?>> structuredState)
			statePayload = PrepareStatePayload(structuredState, out originalFormat);

		WriteTimestamp(stamp);
		WriteLogLevel(logLevel);
		WriteContext(context);
		WriteMessage(message);
		WriteEventId(eventId);
		WriteException(exception);
		WriteFormat(originalFormat);
		WriteState(statePayload);
	}

	protected abstract void WriteContext(string context);

	protected abstract void WriteEventId(in EventId eventId);

	protected abstract void WriteException(Exception? exception);

	protected abstract void WriteFormat(string? messageFormat);

	protected abstract void WriteLogLevel(in LogLevel logLevel);

	protected abstract void WriteMessage(string? message);

	protected abstract void WriteState(object? state);

	protected abstract void WriteTimestamp(in DateTimeOffset timestamp);
}
