using System.Collections.Concurrent;
using System.Runtime.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
namespace Profit.Integrator.Logging
{
	[UnsupportedOSPlatform("browser")]
    [ProviderAlias("PostgrePitLog")]
    public sealed class PostgreLogProvider : ILoggerProvider
    {
        private readonly IDisposable? _onChangeToken;
        private NpgsqlConnectionStringBuilder _currentConfig;
        private readonly ConcurrentDictionary<string, PostgreLogger> _loggers = new(StringComparer.OrdinalIgnoreCase);
        public PostgreLogProvider(NpgsqlConnectionStringBuilder config)
        {
            _currentConfig = config;
        }
        public PostgreLogProvider(IOptionsMonitor<NpgsqlConnectionStringBuilder> config)
        {
            _currentConfig = config.CurrentValue;
            _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new PostgreLogger(name, GetCurrentConfig));

        private NpgsqlConnectionStringBuilder GetCurrentConfig() => _currentConfig;

        public void Dispose()
        {
            foreach (var logger in _loggers.Values)
                logger.Flush();
            _loggers.Clear();
            Console.WriteLine("Flushed");
#if DEBUG
            Console.ReadKey(); 
#endif
            _onChangeToken?.Dispose();
        }
    }
}


