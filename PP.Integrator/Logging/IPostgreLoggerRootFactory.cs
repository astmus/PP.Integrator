using Microsoft.Extensions.Logging;
using Npgsql;

namespace PP.Integrator.Logging
{
	internal interface IPostgreLoggerRootFactory
	{
		PostgreLoggerBase CreateRootLogger(
			string categoryName,
			Func<NpgsqlConnectionStringBuilder> getCurrentConfig,
			PostgreLoggerProviderOptions options,
			LogLevel defaultLogLevel);
	}
}
