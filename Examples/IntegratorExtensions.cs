using Examples;

namespace PP.Integrator
{
	public static class IntegratorLoggerExtensions
	{
		public static IServiceCollection AddLoggingExamples(this IServiceCollection services)
		{
			services.AddHostedService<LoggingExampleSecond>().AddHostedService<LoggingExample>();
			return services;
		}
	}
}


