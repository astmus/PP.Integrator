namespace PP.Integrator.Logging
{
	internal interface IPostgreLoggerRootFactory
	{
		PostgreLogger CreateRootLogger(IPostgreLoggingDataSourceAccessor dataSourceAccessor, PostgreLoggerProviderOptions options);
	}
}
