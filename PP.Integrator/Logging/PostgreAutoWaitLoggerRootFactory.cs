using Microsoft.Extensions.Logging;
using Npgsql;

namespace PP.Integrator.Logging
{
	internal sealed class PostgreAutoWaitLoggerRootFactory : IPostgreLoggerRootFactory
	{
		public PostgreLoggerBase CreateRootLogger(
			string categoryName,
			NpgsqlDataSource dataSource,
			PostgreLoggerProviderOptions options,
			LogLevel defaultLogLevel) =>
			new PostgreLoggerAutoWait(categoryName, dataSource, options, defaultLogLevel);
	}
}
