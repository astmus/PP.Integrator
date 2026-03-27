namespace PP.Integrator.Logging
{
	internal sealed class PostgreClassicLoggerRootFactory : IPostgreLoggerRootFactory
	{
		public PostgreLoggerBase CreateRootLogger(IPostgreLoggingDataSourceAccessor dataSourceAccessor, PostgreLoggerProviderOptions options) =>
			new PostgreLoggerClassic(dataSourceAccessor, options);
	}
}
