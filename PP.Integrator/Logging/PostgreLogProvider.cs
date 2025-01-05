using System.Collections.Concurrent;
using System.Runtime.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
namespace PP.Integrator.Logging
{
	[UnsupportedOSPlatform("browser")]
	[ProviderAlias("PostgrePitLog")]
	public sealed class PostgreLogProvider : ILoggerProvider
	{
		private readonly IDisposable? _onChangeToken;
		private NpgsqlConnectionStringBuilder _currentConfig;
		private readonly ConcurrentDictionary<string, PostgreLogger.DelegatedLogger> _loggers = new(StringComparer.OrdinalIgnoreCase);
		private PostgreLogger _rootLogger;
		public PostgreLogProvider(NpgsqlConnectionStringBuilder config)
		{
			_currentConfig = config;
		}
		public PostgreLogProvider(IOptionsMonitor<NpgsqlConnectionStringBuilder> config)
		{
			_currentConfig = config.CurrentValue;
			//_onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
		}

		public ILogger CreateLogger(string categoryName)
		{
			_rootLogger ??= new PostgreLogger(categoryName, GetCurrentConfig);
			return _loggers.GetOrAdd(categoryName, name => new PostgreLogger.DelegatedLogger(name, _rootLogger));
		}

		private NpgsqlConnectionStringBuilder GetCurrentConfig() => _currentConfig;

		public void Dispose()
		{
			_rootLogger.Flush();
			_loggers.Clear();
			
#if DEBUG
			Console.WriteLine("Flushed");
			Console.ReadKey();
#endif
			_onChangeToken?.Dispose();
		}
	}
}


