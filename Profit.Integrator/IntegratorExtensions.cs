using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Npgsql;
using Profit.Integrator.Logging;

namespace Profit.Integrator
{
	public static class IntegratorLoggerExtensions
	{
		public static ILoggingBuilder AddPostgreLogger(this ILoggingBuilder builder, Action<NpgsqlConnectionStringBuilder> configure)
		{
			builder.Services.Configure(configure);			
			builder.AddConfiguration();
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, PostgreLogProvider>());
			LoggerProviderOptions.RegisterProviderOptions<NpgsqlConnectionStringBuilder, PostgreLogProvider>(builder.Services);
			return builder;
		}
	}
}


