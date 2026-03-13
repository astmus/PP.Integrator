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
		private readonly NpgsqlDataSource dataSource;
		private readonly ConcurrentDictionary<string, ILogger> _loggers = new(StringComparer.OrdinalIgnoreCase);
		private readonly PostgreLoggerProviderOptions _options;
		private readonly LogLevel _defaultLogLevel;
		private readonly IPostgreLoggerRootFactory _rootFactory;
		private PostgreLoggerBase? _rootLogger;

		public PostgreLogProvider(
			NpgsqlDataSource dataSource,
			PostgreLoggerProviderOptions options,
			LogLevel defaultLogLevel,
			IPostgreLoggerRootFactory rootFactory)
		{
			this.dataSource = dataSource;
			_options = options;
			_defaultLogLevel = defaultLogLevel;
			_rootFactory = rootFactory;
		}

		public PostgreLogProvider(
			NpgsqlDataSource dataSource,
			IOptions<PostgreLoggerProviderOptions> options,
			IOptions<LoggerFilterOptions> loggerFilterOptions,
			IPostgreLoggerRootFactory rootFactory)
			: this(
				dataSource,
				options.Value,
				ResolveDefaultLogLevel(options.Value, loggerFilterOptions.Value),
				rootFactory)
		{
		}

		public ILogger CreateLogger(string categoryName) =>
			_loggers.GetOrAdd(categoryName, CreateDelegatedLogger);

		private ILogger CreateDelegatedLogger(string categoryName)
		{
			_rootLogger ??= _rootFactory.CreateRootLogger(categoryName, dataSource, _options, _defaultLogLevel);
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

