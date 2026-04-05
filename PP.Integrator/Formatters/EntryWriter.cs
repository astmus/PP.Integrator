using System;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using PP.Integrator.Logging;

namespace PP.Integrator.Formatters;

internal abstract class EntryWriter : ILogEntryWriter
{
	protected static readonly JsonWriterOptions _jsonWriterOptions = new JsonWriterOptions() { Indented = false, SkipValidation = true };
	protected const string OriginalFormatKey = "{OriginalFormat}";

	public virtual void OnAfterEntryWrite() { }

	public virtual void OnBeforeEntryWrite() { }

	public void Write<TState>(in LogEntry<TState> logEntry, object scope)
	{
		OnBeforeEntryWrite();
		var message = logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception) ?? logEntry.State?.ToString();
		WriteInternal(message, logEntry.LogLevel, logEntry.Category, logEntry.EventId.Id, logEntry.Exception, logEntry.State, logEntry.Timestamp);
		OnAfterEntryWrite();
	}

	private static string TryGetFormat(object state)
	{
		if (state is not IReadOnlyList<KeyValuePair<string, object?>> structuredState)
			return null;

		for (var i = 0; i < structuredState.Count; i++)
		{
			if (string.Equals(structuredState[i].Key, OriginalFormatKey, StringComparison.OrdinalIgnoreCase))
				return structuredState[i].Value.ToString();
		}

		return null;
	}

	protected void WriteInternal(string? message, in LogLevel logLevel, string context, in int eventId, Exception? exception, object? state, in DateTimeOffset stamp)
	{
		var originalFormat = TryGetFormat(state);		

		WriteTimestamp(stamp);
		WriteLogLevel(logLevel);
		WriteContext(context);
		WriteMessage(message);
		WriteEventId(eventId);
		WriteException(exception);
		WriteFormat(originalFormat);
		WriteState(state);
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
