using Microsoft.Extensions.Logging;
using Npgsql;

namespace PP.Integrator.Logging
{
	internal sealed class PostgreAutoWaitLoggerRootFactory : IPostgreLoggerRootFactory
	{
		public PostgreLoggerBase CreateRootLogger(
			string categoryName,
			Func<NpgsqlConnectionStringBuilder> getCurrentConfig,
			PostgreLoggerProviderOptions options,
			LogLevel defaultLogLevel) =>
			new PostgreLoggerAutoWait(categoryName, getCurrentConfig, options, defaultLogLevel);
	}
}
