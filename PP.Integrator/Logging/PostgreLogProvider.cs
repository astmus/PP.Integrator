using System.Collections.Concurrent;
using System.Runtime.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
namespace PP.Integrator.Logging
{
	[UnsupportedOSPlatform("browser")]
	[ProviderAlias("PostgreLog")]	
	internal sealed class PostgreLogProvider : ILoggerProvider
	{
		private NpgsqlConnectionStringBuilder _currentConfig;
		private readonly ConcurrentDictionary<string, ILogger> _loggers = new(StringComparer.OrdinalIgnoreCase);
		private readonly PostgreLoggerProviderOptions _options;
		private readonly LogLevel _defaultLogLevel;
		private readonly IPostgreLoggerRootFactory _rootFactory;
		private PostgreLoggerBase? _rootLogger;
				
		public PostgreLogProvider(
			NpgsqlConnectionStringBuilder config,
			PostgreLoggerProviderOptions options,
			LogLevel defaultLogLevel,
			IPostgreLoggerRootFactory rootFactory)
		{
			_currentConfig = config;
			_options = options;
			_defaultLogLevel = defaultLogLevel;
			_rootFactory = rootFactory;
		}
		
		public PostgreLogProvider(
			IOptionsMonitor<NpgsqlConnectionStringBuilder> config,
			IOptions<PostgreLoggerProviderOptions> options,
			IOptions<LoggerFilterOptions> loggerFilterOptions,
			IPostgreLoggerRootFactory rootFactory)
			: this(
				config.CurrentValue,
				options.Value,
				ResolveDefaultLogLevel(options.Value, loggerFilterOptions.Value),
				rootFactory)
		{
		}
				
		public ILogger CreateLogger(string categoryName)
		{
			return _loggers.GetOrAdd(categoryName, name => CreateDelegatedLogger(name));
		}

		private NpgsqlConnectionStringBuilder GetCurrentConfig() => _currentConfig;
		private ILogger CreateDelegatedLogger(string categoryName)
		{
			_rootLogger ??= _rootFactory.CreateRootLogger(categoryName, GetCurrentConfig, _options, _defaultLogLevel);
			return new PostgreDelegatedLogger(categoryName, _rootLogger);
		}

		public void Dispose()
		{
			_rootLogger?.Flush();
			_loggers.Clear();
			
#if DEBUG
			Console.WriteLine("Logger disposed");
#endif
		}

		private static LogLevel ResolveDefaultLogLevel(PostgreLoggerProviderOptions options, LoggerFilterOptions filterOptions)
		{
			if (options.DefaultLogLevel.HasValue)
				return options.DefaultLogLevel.Value;

			return filterOptions.MinLevel;
		}
	}
}


