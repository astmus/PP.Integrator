namespace PP.Integrator.Logging
{
	internal sealed class PostgreAutoWaitLoggerRootFactory : IPostgreLoggerRootFactory
	{
		public PostgreLoggerBase CreateRootLogger(IPostgreLoggingDataSourceAccessor dataSourceAccessor, PostgreLoggerProviderOptions options) =>
			new PostgreLoggerAutoWait(dataSourceAccessor, options);
	}
}
