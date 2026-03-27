namespace PP.Integrator.Logging
{
	internal interface IPostgreLoggerRootFactory
	{
		PostgreLoggerBase CreateRootLogger(IPostgreLoggingDataSourceAccessor dataSourceAccessor, PostgreLoggerProviderOptions options);
	}
}
