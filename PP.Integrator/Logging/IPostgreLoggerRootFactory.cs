using Microsoft.Extensions.Logging;
using Npgsql;

namespace PP.Integrator.Logging
{
	internal interface IPostgreLoggerRootFactory
	{
		PostgreLoggerBase CreateRootLogger(
			string categoryName,
			IPostgreLoggingDataSourceAccessor dataSourceAccessor,
			PostgreLoggerProviderOptions options);
	}
}
