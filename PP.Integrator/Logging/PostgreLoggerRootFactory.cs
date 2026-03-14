using Microsoft.Extensions.Logging;
using Npgsql;

namespace PP.Integrator.Logging
{
	internal sealed class PostgreLoggerRootFactory : IPostgreLoggerRootFactory
	{
		public PostgreLoggerBase CreateRootLogger(
			string categoryName,
			NpgsqlDataSource dataSource,
		PostgreLoggerProviderOptions options) =>
		new PostgreLoggerAutoWait(categoryName, dataSource, options);
	}
}
