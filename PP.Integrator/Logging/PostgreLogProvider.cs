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
		private readonly IPostgreLoggingDataSourceAccessor _dataSourceAccessor;
		private readonly ConcurrentDictionary<string, ILogger> _loggers = new(StringComparer.OrdinalIgnoreCase);
		private readonly PostgreLoggerProviderOptions _options;
		private readonly IPostgreLoggerRootFactory _rootFactory;
		private readonly object _rootSync = new();
		private PostgreLoggerBase? _rootLogger;
		private int _disposed;

		public PostgreLogProvider(IPostgreLoggingDataSourceAccessor dataSourceAccessor, PostgreLoggerProviderOptions options, IPostgreLoggerRootFactory rootFactory)
		{
			_dataSourceAccessor = dataSourceAccessor;
			_options = options;
			_rootFactory = rootFactory;
		}

		public PostgreLogProvider(IPostgreLoggingDataSourceAccessor dataSourceAccessor, IOptions<PostgreLoggerProviderOptions> options, IOptions<LoggerFilterOptions> loggerFilterOptions, IPostgreLoggerRootFactory rootFactory)
			: this(dataSourceAccessor, options.Value, rootFactory)
		{
		}

		public ILogger CreateLogger(string categoryName)
		{
			if (Volatile.Read(ref _disposed) == 1)
				throw new ObjectDisposedException(nameof(PostgreLogProvider));

			return _loggers.GetOrAdd(categoryName, CreateDelegatedLogger);
		}

		private ILogger CreateDelegatedLogger(string categoryName)
		{
			var root = EnsureRootLogger(categoryName);
			return new PostgreDelegatedLogger(categoryName, root);
		}

		public void Dispose()
		{
			if (Interlocked.Exchange(ref _disposed, 1) == 1)
				return;

			_rootLogger?.Dispose();
			_loggers.Clear();

#if DEBUG
			Console.WriteLine("Logger disposed");
#endif
		}

		private PostgreLoggerBase EnsureRootLogger(string categoryName)
		{
			var existing = Volatile.Read(ref _rootLogger);
			if (existing != null)
				return existing;

			lock (_rootSync)
			{
				existing = _rootLogger;
				if (existing != null)
					return existing;

				existing = _rootFactory.CreateRootLogger(categoryName, _dataSourceAccessor, _options);
				_rootLogger = existing;
				return existing;
			}
		}
	}
}

