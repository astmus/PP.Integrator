using Microsoft.Extensions.Logging;
using Npgsql;
using NpgsqlTypes;
using Profit.Integrator.Formatters;
using System;
using System.IO;

namespace Profit.Integrator.Logging
{
    public static partial class Log
    {
        [LoggerMessage(EventId = 23, Message = "{name} lives in {city}.", Level = LogLevel.Information)]
        public static partial void PlaceOfResidence(
            this ILogger logger,
            LogLevel logLevel,
            string name,
            string city);
    }

    public sealed class PostgreLogger : ILogger
    {
        [ThreadStatic]
        private static StringWriter _stringWriter;
        private readonly string _name;
        private readonly Func<NpgsqlConnectionStringBuilder> _currentConfig;
        private static readonly Lazy<BufferLogRecordProcessor> _lazeProcess = new Lazy<BufferLogRecordProcessor>(() => new BufferLogRecordProcessor(2048), true);
        private IExternalScopeProvider ScopeProvider = new LogScopesProvider();
        private JsonFormatter Formatter = new JsonFormatter();
        private BufferCollection<LogRecord> _logQueue => _lazeProcess.Value.Queue;
        NpgsqlDataSource _source;
        Action? _initialize;

        public PostgreLogger(string name, Func<NpgsqlConnectionStringBuilder> getCurrentConfig)
        {
            _name = name;
            _currentConfig = getCurrentConfig;
            _initialize = Initialize;
        }

        void Initialize()
        {
            _initialize = null;
            _source ??= NpgsqlDataSource.Create(_currentConfig());
            if (_lazeProcess.IsValueCreated == false)
                _lazeProcess.Value.RunProcessing(ProcessQueue);
        }

        public IDisposable BeginScope<TState>(TState state)
            => ScopeProvider?.Push(state) ?? NullScope.Instance;

        public bool IsEnabled(LogLevel logLevel) =>
            logLevel != LogLevel.None;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            _initialize?.Invoke();

            _logQueue.Add(new LogRecord<TState>(new LogEntry<TState>(logLevel, _name, eventId, state, exception, formatter, ScopeProvider)));
        }

        private static void ThrowLoggingError(params Exception[] exceptions)
        {
            throw new AggregateException(message: "An error occurred while writing to logger(s).", innerExceptions: exceptions);
        }

        private void ProcessQueue()
        {
            try
            {
                _stringWriter ??= new UtfWriter();
                foreach (var items in _logQueue.BufferButches(512))
                {
                    using var conn = _source.OpenConnection();
                    using var writer = conn.BeginBinaryImport("COPY logs.backgroundjobs (value) FROM STDIN (FORMAT BINARY)");

                    foreach (var logItem in items)
                    {
                        logItem.Deconstruct(out var writeAction);
                        writeAction(Formatter, _stringWriter);
                        var sb = _stringWriter.GetStringBuilder();
                        if (sb.Length == 0) continue;

                        writer.StartRow();
                        writer.Write(sb.ToString(), NpgsqlDbType.Jsonb);
                        sb.Clear();
                    }
                    writer.Complete();
                }
            }
            catch (Exception error)
            {
                ThrowLoggingError(error);
            }
        }
    }
}


