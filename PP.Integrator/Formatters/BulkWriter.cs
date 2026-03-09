using System.Text.Json;
using Microsoft.Extensions.Logging;
using Npgsql;
using NpgsqlTypes;

namespace PP.Integrator.Formatters;

internal sealed class BulkWriter : EntryWriter, IDisposable
{
	private static readonly JsonSerializerOptions WriteOptions = new()
	{
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
	};

	private bool _disposed;
	private NpgsqlBinaryImporter? _writer;

	public BulkWriter(NpgsqlBinaryImporter writer) => _writer = writer;

	public void Dispose()
	{
		if (_disposed)
			return;

		_writer!.Complete();
		_writer = null;
		_disposed = true;
	}

	public override void OnBeforeEntryWrite() => _writer!.StartRow();

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
		if (value == null)
		{
			_writer!.WriteNull();
			return;
		}

		_writer!.Write(JsonSerializer.Serialize(value, WriteOptions), NpgsqlDbType.Jsonb);
	}

	private void WriteText(string? value)
	{
		if (value == null)
		{
			_writer!.WriteNull();
			return;
		}

		_writer!.Write(value);
	}

	protected override void WriteContext(string context) => _writer!.Write(context);

	protected override void WriteEventId(in EventId eventId) => _writer!.Write(eventId.Id, NpgsqlDbType.Integer);

	protected override void WriteException(Exception? exception) => WriteJson(exception);

	protected override void WriteFormat(string? messageFormat) => WriteText(messageFormat);

	protected override void WriteLogLevel(in LogLevel logLevel) => WriteText(GetLogLevelName(logLevel));

	protected override void WriteMessage(string? message) => WriteText(message);

	protected override void WriteState(object? state) => WriteJson(state);

	protected override void WriteTimestamp(in DateTimeOffset timestamp) => _writer!.Write(timestamp);
}
