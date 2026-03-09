using Microsoft.Extensions.Logging;
using Npgsql;

namespace PP.Integrator.Logging
{
	internal sealed class PostgreClassicLoggerRootFactory : IPostgreLoggerRootFactory
	{
		public PostgreLoggerBase CreateRootLogger(
			string categoryName,
			Func<NpgsqlConnectionStringBuilder> getCurrentConfig,
			PostgreLoggerProviderOptions options,
			LogLevel defaultLogLevel) =>
			new PostgreLoggerClassic(categoryName, getCurrentConfig, options, defaultLogLevel);
	}
}
