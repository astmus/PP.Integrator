using System.Text.Json;
using Microsoft.Extensions.Logging;
using Npgsql;
using NpgsqlTypes;
using PP.Integrator.Logging;
namespace PP.Integrator.Formatters
{
	internal abstract class EntryWriter : ILogEntryWriter
	{
		public virtual void OnBeforeEntryWrite()
		{
		}

		public virtual void OnAfterEntryWrite()
		{
		}

		public void Write<TState>(in LogEntry<TState> logEntry, TextWriter textWriter, object scope)
		{
			OnBeforeEntryWrite();

			string message = logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception) ?? logEntry.State.ToString();

			WriteInternal(scope, textWriter, message, logEntry.LogLevel, logEntry.Category, logEntry.EventId.Id, logEntry.Exception, logEntry.State, logEntry.Timestamp);

			OnAfterEntryWrite();
		}

		protected void WriteInternal(object scopeProvider, TextWriter textWriter, string? message, in LogLevel logLevel, string context, in int eventId, Exception? exception, object? state, in DateTimeOffset stamp)
		{
			var list = state as IReadOnlyList<KeyValuePair<string, object>>;
			WriteTimestamp(stamp);
			WriteLogLevel(logLevel);
			WriteContext(context);
			WriteEventId(eventId);
			WriteFormat(list?.First(item=> item.Key == "{OriginalFormat}").Value.ToString());			
			WriteMessage(message);
			WriteException(exception);
			WriteState(list?.Where(item => item.Key != "{OriginalFormat}").ToArray() ?? state);			
		}

		protected abstract void WriteTimestamp(in DateTimeOffset timestamp);
		protected abstract void WriteLogLevel(in LogLevel logLevel);
		protected abstract void WriteContext(string context);
		protected abstract void WriteEventId(in EventId eventId);
		protected abstract void WriteFormat(string messageFormat);
		protected abstract void WriteMessage(string message);
		protected abstract void WriteException(Exception exception);
		protected abstract void WriteState(object state);
	}

	internal sealed class BulkWriter : EntryWriter, IDisposable
	{
		private static readonly JsonSerializerOptions writeOptions = new JsonSerializerOptions()
		{
			DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
		};
		private NpgsqlBinaryImporter writer;

		public BulkWriter(NpgsqlBinaryImporter writer)
		{
			this.writer = writer;
		}

		public override void OnBeforeEntryWrite()
			=> writer.StartRow();

		protected override void WriteTimestamp(in DateTimeOffset timestamp)
			=> writer.Write(timestamp);
		protected override void WriteLogLevel(in LogLevel logLevel)
			=> writer.Write(logLevel.ToString());
		protected override void WriteContext(string context)
			=> writer.Write(context);
		protected override void WriteEventId(in EventId eventId)
			=> writer.Write(eventId.Id, NpgsqlDbType.Integer);
		protected override void WriteFormat(string messageFormat)
			=> writer.Write(messageFormat);
		protected override void WriteMessage(string message)
			=> writer.Write(message);
		protected override void WriteException(Exception exception)
			=> writer.Write(exception != null ? JsonSerializer.Serialize(exception, writeOptions) : null, NpgsqlDbType.Jsonb);
		protected override void WriteState(object item)
			=> writer.Write(item != null ? JsonSerializer.Serialize(item, writeOptions) : null, NpgsqlDbType.Jsonb);


		private bool disposedValue;

		public void Dispose()
		{
			if (!disposedValue)
			{
				writer.Complete();
				writer = null;
				disposedValue = true;
			}
		}
	}
}


