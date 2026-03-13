using Microsoft.Extensions.Logging;
using Npgsql;

namespace PP.Integrator.Logging
{
	internal interface IPostgreLoggerRootFactory
	{
		PostgreLoggerBase CreateRootLogger(
			string categoryName,
			NpgsqlDataSource dataSource,
			PostgreLoggerProviderOptions options,
			LogLevel defaultLogLevel);
	}
}
