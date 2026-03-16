using Microsoft.Extensions.Logging;
using Npgsql;

namespace PP.Integrator.Logging
{
	internal sealed class PostgreAutoWaitLoggerRootFactory : IPostgreLoggerRootFactory
	{
		public PostgreLoggerBase CreateRootLogger(string categoryName,
			IPostgreLoggingDataSourceAccessor dataSourceAccessor,
			PostgreLoggerProviderOptions options) =>
		new PostgreLoggerAutoWait(categoryName, dataSourceAccessor, options);
	}
}
