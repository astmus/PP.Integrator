using System.Buffers;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Npgsql;
using NpgsqlTypes;

namespace PP.Integrator.Formatters;

internal sealed class BulkWriter : EntryWriter
{
	private const int ExceptionMaxDepth = 4;
	private const int JsonBufferSize = 256;

	private static readonly JsonSerializerOptions _serializeOptions = new()
	{
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, DefaultBufferSize = JsonBufferSize
	};

	private NpgsqlBinaryImporter _importer;

	public BulkWriter(NpgsqlBinaryImporter importer) => _importer = importer;

	public override void OnBeforeEntryWrite() => _importer.StartRow();

	private static string GetLogLevelName(in LogLevel logLevel) => logLevel switch
	{
		LogLevel.Trace => nameof(LogLevel.Trace),
		LogLevel.Debug => nameof(LogLevel.Debug),
		LogLevel.Information => nameof(LogLevel.Information),
		LogLevel.Warning => nameof(LogLevel.Warning),
		LogLevel.Error => nameof(LogLevel.Error),
		LogLevel.Critical => nameof(LogLevel.Critical),
		_ => nameof(LogLevel.None)
	};

	private void WriteJson(object? value)
	{
		switch (value)
		{
			case null:
				_importer.WriteNull();
				break;

			case IReadOnlyList<KeyValuePair<string, object?>> structuredState:
				WriteStructuredState(structuredState);
				break;

			case Exception exception:
				WriteExceptionJson(exception);
				break;

			default:
				_importer.Write(JsonSerializer.SerializeToUtf8Bytes(value, _serializeOptions), NpgsqlDbType.Jsonb);
				break;
		}
	}

	private void WriteStructuredState(IReadOnlyList<KeyValuePair<string, object?>> structuredState)
	{
		var output = new ArrayBufferWriter<byte>(JsonBufferSize);
		using var jsonWriter = new Utf8JsonWriter(output, _jsonWriteroptions);

		jsonWriter.WriteStartObject();

		for (var i = 0; i < structuredState.Count; i++)
		{
			var item = structuredState[i];
			if (string.Equals(item.Key, OriginalFormatKey, StringComparison.Ordinal))
				continue;

			WriteJsonProperty(jsonWriter, item.Key, item.Value);
		}

		jsonWriter.WriteEndObject();
		jsonWriter.Flush();

#if NET8_0_OR_GREATER
		_importer.Write(output.WrittenMemory, NpgsqlDbType.Jsonb);
#else 
		_importer.Write(output.WrittenMemory.ToArray(), NpgsqlDbType.Jsonb);
#endif
	}

	

	private void WriteExceptionJson(Exception exception)
	{
		var output = new ArrayBufferWriter<byte>(JsonBufferSize);
		using var jsonWriter = new Utf8JsonWriter(output);
		WriteExceptionObject(jsonWriter, exception, 0);
		jsonWriter.Flush();
#if NET8_0_OR_GREATER
		_importer.Write(output.WrittenMemory, NpgsqlDbType.Jsonb);
#else
		_importer.Write(output.WrittenSpan.ToArray(), NpgsqlDbType.Jsonb);
#endif
	}

	private static void WriteExceptionObject(Utf8JsonWriter jsonWriter, Exception exception, int depth)
	{
		jsonWriter.WriteStartObject();
		jsonWriter.WriteString("Type", exception.GetType().FullName);
		jsonWriter.WriteString("Message", exception.Message);
		if (!string.IsNullOrWhiteSpace(exception.StackTrace))
			jsonWriter.WriteString("StackTrace", exception.StackTrace);
		if (!string.IsNullOrWhiteSpace(exception.Source))
			jsonWriter.WriteString("Source", exception.Source);
		if (exception.HResult != 0)
			jsonWriter.WriteNumber("HResult", exception.HResult);

		if (exception.InnerException != null && depth < ExceptionMaxDepth)
		{
			jsonWriter.WritePropertyName("InnerException");
			WriteExceptionObject(jsonWriter, exception.InnerException, depth + 1);
		}

		jsonWriter.WriteEndObject();
	}

	private static void WriteJsonProperty(Utf8JsonWriter jsonWriter, string propertyName, object? value)
	{
		switch (value)
		{
			case null:
				jsonWriter.WriteNull(propertyName);
				break;
			case string text:
				jsonWriter.WriteString(propertyName, text);
				break;
			case bool current:
				jsonWriter.WriteBoolean(propertyName, current);
				break;
			case int current:
				jsonWriter.WriteNumber(propertyName, current);
				break;
			case long current:
				jsonWriter.WriteNumber(propertyName, current);
				break;
			case short current:
				jsonWriter.WriteNumber(propertyName, current);
				break;
			case uint current:
				jsonWriter.WriteNumber(propertyName, current);
				break;
			case ulong current:
				jsonWriter.WriteNumber(propertyName, current);
				break;
			case ushort current:
				jsonWriter.WriteNumber(propertyName, current);
				break;
			case byte current:
				jsonWriter.WriteNumber(propertyName, current);
				break;
			case sbyte current:
				jsonWriter.WriteNumber(propertyName, current);
				break;
			case float current:
				jsonWriter.WriteNumber(propertyName, current);
				break;
			case double current:
				jsonWriter.WriteNumber(propertyName, current);
				break;
			case decimal current:
				jsonWriter.WriteNumber(propertyName, current);
				break;
			case Guid current:
				jsonWriter.WriteString(propertyName, current);
				break;
			case DateTime current:
				jsonWriter.WriteString(propertyName, current);
				break;
			case DateTimeOffset current:
				jsonWriter.WriteString(propertyName, current);
				break;
			default:
				jsonWriter.WritePropertyName(propertyName);
				JsonSerializer.Serialize(jsonWriter, value, _serializeOptions);
				break;
		}
	}

	private void WriteText(string? value)
	{
		if (value == null)
			_importer.WriteNull();
		else
			_importer.Write(value);
	}

	protected override void WriteContext(string context) => _importer.Write(context);

	protected override void WriteEventId(in EventId eventId) => _importer.Write(eventId.Id, NpgsqlDbType.Integer);

	protected override void WriteException(Exception? exception) => WriteJson(exception);

	protected override void WriteFormat(string? messageFormat) => WriteText(messageFormat);

	protected override void WriteLogLevel(in LogLevel logLevel) => WriteText(GetLogLevelName(logLevel));

	protected override void WriteMessage(string? message) => WriteText(message);

	protected override void WriteState(object? state) => WriteJson(state);

	protected override void WriteTimestamp(in DateTimeOffset timestamp)
		=> _importer.Write(timestamp, NpgsqlDbType.TimestampTz);
}
