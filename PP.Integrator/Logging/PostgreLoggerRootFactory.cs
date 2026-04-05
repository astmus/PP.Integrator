namespace PP.Integrator.Logging
{
	internal sealed class PostgreLoggerRootFactory : IPostgreLoggerRootFactory
	{
		public PostgreLogger CreateRootLogger(IPostgreLoggingDataSourceAccessor dataSourceAccessor, PostgreLoggerProviderOptions options) =>
			new(dataSourceAccessor, options);
	}
}
