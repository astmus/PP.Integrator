namespace PP.Integrator.Logging
{
	internal sealed class PostgreClassicLoggerRootFactory : IPostgreLoggerRootFactory
	{
		public PostgreLoggerBase CreateRootLogger(string categoryName,
			IPostgreLoggingDataSourceAccessor dataSourceAccessor,
			PostgreLoggerProviderOptions options) =>
		new PostgreLoggerClassic(categoryName, dataSourceAccessor, options);
	}
}
