using Microsoft.Extensions.Logging;
using Npgsql;

namespace PP.Integrator.Logging
{
	internal sealed class PostgreClassicLoggerRootFactory : IPostgreLoggerRootFactory
	{
		public PostgreLoggerBase CreateRootLogger(
			string categoryName,
			NpgsqlDataSource dataSource,
		PostgreLoggerProviderOptions options) =>
		new PostgreLoggerClassic(categoryName, dataSource, options);
	}
}
