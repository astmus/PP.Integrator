using System.Collections.Concurrent;
using System.Runtime.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PP.Integrator.Logging
{
	[UnsupportedOSPlatform("browser")]
	[ProviderAlias("Postgre")]
	internal sealed class PostgreLogProvider : ILoggerProvider
	{
		private readonly IPostgreLoggingDataSourceAccessor _dataSourceAccessor;
		private readonly ConcurrentDictionary<string, ILogger> _loggers = new(StringComparer.OrdinalIgnoreCase);
		private readonly PostgreLoggerProviderOptions _options;
		private readonly IPostgreLoggerRootFactory _rootFactory;
		private readonly object _rootSync = new();
		private PostgreLogger? _rootLogger;
		private int _disposed;

		public PostgreLogProvider(IPostgreLoggingDataSourceAccessor dataSourceAccessor, PostgreLoggerProviderOptions options, IPostgreLoggerRootFactory rootFactory)
		{
			_dataSourceAccessor = dataSourceAccessor;
			_options = options;
			_rootFactory = rootFactory;
		}

		public PostgreLogProvider(IPostgreLoggingDataSourceAccessor dataSourceAccessor, IOptions<PostgreLoggerProviderOptions> options, IPostgreLoggerRootFactory rootFactory)
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
			var root = EnsureRootLogger();
			return new PostgreDelegatedLogger(categoryName, root);
		}

		public void Dispose()
		{
			if (Interlocked.Exchange(ref _disposed, 1) == 1)
				return;

			_rootLogger?.Dispose();
			_loggers.Clear();
		}

		private PostgreLogger EnsureRootLogger()
		{
			var existing = Volatile.Read(ref _rootLogger);
			if (existing != null)
				return existing;

			lock (_rootSync)
			{
				existing = _rootLogger;
				if (existing != null)
					return existing;

				existing = _rootFactory.CreateRootLogger(_dataSourceAccessor, _options);
				_rootLogger = existing;
				return existing;
			}
		}
	}
}
