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

	public void Write<TState>(in LogRecord<TState> record, object scope)
	{
		var errorBytes = record.ErrorBytes;
		var stateBytes = record.StateBytes;

		record.Deconstruct(out var logEntry, out var logScope);

		OnBeforeEntryWrite();
		var message = logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception) ?? logEntry.State?.ToString();

		var originalFormat = TryGetFormat(logEntry.State);

		WriteTimestamp(logEntry.Timestamp);
		WriteLogLevel(logEntry.LogLevel);
		WriteContext(logEntry.Category);
		WriteMessage(message);
		WriteEventId(logEntry.EventId);

		if (errorBytes != null)
			WriteRawBytes(errorBytes);
		else
			WriteException(logEntry.Exception);

		WriteFormat(originalFormat);

		if (stateBytes != null)
			WriteRawBytes(stateBytes);
		else
			WriteState(logEntry.State);
		
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

	protected abstract void WriteRawBytes(in byte[] bytes);

	protected abstract void WriteContext(string context);

	protected abstract void WriteEventId(in EventId eventId);

	protected abstract void WriteException(Exception? exception);

	protected abstract void WriteFormat(string? messageFormat);

	protected abstract void WriteLogLevel(in LogLevel logLevel);

	protected abstract void WriteMessage(string? message);

	protected abstract void WriteState(object? state);

	protected abstract void WriteTimestamp(in DateTimeOffset timestamp);
}
