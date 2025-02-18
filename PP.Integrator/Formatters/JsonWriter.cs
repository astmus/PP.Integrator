﻿using System.Buffers;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using PP.Integrator.Logging;
namespace PP.Integrator.Formatters
{
	internal sealed class JsonFormatter : ILogEntryWriter
    {
        private const string T = "Trace";
        private const string D = "Debug";
        private const string I = "Information";
        private const string W = "Warning";
        private const string E = "Error";
        private const string C = "Critical";
        const int DefaultBufferSize = 1024;
        const string DateFormat = "yyyy.MM.dd hh:mm:ss";
        static readonly JsonWriterOptions _options;
		public void Write<TState>(in LogEntry<TState> logEntry, TextWriter textWriter, object scope)
        {
            var scopeProvider = scope as IExternalScopeProvider;
			if (logEntry.State is IReadOnlyList<KeyValuePair<string, object>> state)
            {
                string message = logEntry.Formatter(logEntry.State, logEntry.Exception) ?? string.Empty;
                WriteInternal(scopeProvider, textWriter, message, logEntry.LogLevel, logEntry.Category, logEntry.EventId.Id, logEntry.Exception?.Message,
                   true, null, state, logEntry.Timestamp);
            }
            else
            {
                if (logEntry.Formatter != null && logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception) is string message)
                    WriteInternal(scopeProvider, textWriter, message, logEntry.LogLevel, logEntry.Category, logEntry.EventId.Id, logEntry.Exception?.ToString(),
                        logEntry.State != null, logEntry.State?.ToString(), logEntry.State as IReadOnlyList<KeyValuePair<string, object?>>, logEntry.Timestamp);
                else
                    WriteInternal(scopeProvider, textWriter, JsonSerializer.Serialize(logEntry.State), logEntry.LogLevel, logEntry.Category, logEntry.EventId.Id, logEntry.Exception?.ToString(),
                    logEntry.State != null, logEntry.State?.ToString(), logEntry.State as IReadOnlyList<KeyValuePair<string, object?>>, logEntry.Timestamp);
            }
        }

        private static void WriteInternal(IExternalScopeProvider? scopeProvider, TextWriter textWriter, in string? message, LogLevel logLevel,
            string category, int eventId, string? exception, bool hasState, in string? stateMessage, IReadOnlyList<KeyValuePair<string, object?>>? stateProperties, in DateTimeOffset stamp)
        {
            var output = new ArrayBufferWriter<byte>(DefaultBufferSize);

            using (var writer = new Utf8JsonWriter(output, _options))
            {
                writer.WriteStartObject();

                writer.WriteString("Timestamp", stamp.ToString(DateFormat,default));

                writer.WriteNumber(nameof(LogEntry<object>.EventId), eventId);
                writer.WriteString(nameof(LogEntry<object>.LogLevel), GetLogLevelString(in logLevel));
                writer.WriteString(nameof(LogEntry<object>.Category), category);
                writer.WriteString("Message", message);

                if (exception != null)
                    writer.WriteString(nameof(Exception), exception);

                if (hasState)
                {
                    writer.WriteStartObject(nameof(LogEntry<object>.State));
                    writer.WriteString("Message", stateMessage);

                    if (stateProperties != null)
                        foreach (KeyValuePair<string, object?> item in stateProperties)
                            WriteItem(writer, item);

                    writer.WriteEndObject();
                }
                writer.WriteEndObject();
                writer.Flush();
            }

            var logEntryBytes = output.WrittenMemory.Span;
            var logEntryBuffer = ArrayPool<char>.Shared.Rent(Encoding.UTF8.GetMaxCharCount(logEntryBytes.Length));
            try
            {
                var charsWritten = Encoding.UTF8.GetChars(logEntryBytes, logEntryBuffer);
                textWriter.Write(logEntryBuffer, 0, charsWritten);
            }
            finally
            {
                ArrayPool<char>.Shared.Return(logEntryBuffer);
            }

            textWriter.Write(Environment.NewLine);
        }

        static string GetLogLevelString(in LogLevel logLevel) => logLevel switch
        {
            LogLevel.Trace => T,
            LogLevel.Debug => D,
            LogLevel.Information => I,
            LogLevel.Warning => W,
            LogLevel.Error => E,
            LogLevel.Critical => C,
            _ => throw new ArgumentOutOfRangeException(nameof(logLevel))
        };

        private static void WriteScopeInfo(Utf8JsonWriter writer, IExternalScopeProvider? scopeProvider)
        {
            if (scopeProvider == null) return;

            writer.WriteStartArray("Scopes");

            scopeProvider.ForEachScope((scope, state) =>
            {
                if (scope is IEnumerable<KeyValuePair<string, object?>> scopeItems)
                {
                    state.WriteStartObject();
                    state.WriteString("Message", scope.ToString());
                    foreach (KeyValuePair<string, object?> item in scopeItems)
                        WriteItem(state, item);
                    state.WriteEndObject();
                }
                else
                    state.WriteStringValue(Convert.ToString(scope, CultureInfo.InvariantCulture));
            }, writer);

            writer.WriteEndArray();
        }

        private static void WriteItem(Utf8JsonWriter writer, KeyValuePair<string, object?> item)
        {
            var key = item.Key;
            switch (item.Value)
            {
                case bool boolValue:
                writer.WriteBoolean(key, boolValue);
                break;
                case byte byteValue:
                writer.WriteNumber(key, byteValue);
                break;
                case sbyte sbyteValue:
                writer.WriteNumber(key, sbyteValue);
                break;
                case char charValue:
                writer.WriteString(key, MemoryMarshal.CreateSpan(ref charValue, 1));
                break;
                case decimal decimalValue:
                writer.WriteNumber(key, decimalValue);
                break;
                case double doubleValue:
                writer.WriteNumber(key, doubleValue);
                break;
                case float floatValue:
                writer.WriteNumber(key, floatValue);
                break;
                case int intValue:
                writer.WriteNumber(key, intValue);
                break;
                case uint uintValue:
                writer.WriteNumber(key, uintValue);
                break;
                case long longValue:
                writer.WriteNumber(key, longValue);
                break;
                case ulong ulongValue:
                writer.WriteNumber(key, ulongValue);
                break;
                case short shortValue:
                writer.WriteNumber(key, shortValue);
                break;
                case ushort ushortValue:
                writer.WriteNumber(key, ushortValue);
                break;
                case null:
                writer.WriteNull(key);
                break;
                default:
                writer.WriteString(key, Convert.ToString(item.Value, CultureInfo.InvariantCulture));
                break;
            }
        }
    }
}


