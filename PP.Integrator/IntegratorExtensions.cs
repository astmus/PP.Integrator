using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Npgsql;
using PP.Integrator.Logging;

namespace PP.Integrator
{	
	/// 	
	public static class IntegratorLoggerExtensions
	{
		/// <summary>
		/// Добавляет bulk логирование в postgre базу данных
		/// </summary>
		/// <param name="builder"></param>
		/// <param name="configure">Настройка подключения к базе</param>
		/// <param name="backCompatibility">True если нужна обратная совместимость</param>
		/// <returns></returns>
		public static ILoggingBuilder AddPostgreLogger(this ILoggingBuilder builder, Action<NpgsqlConnectionStringBuilder> configure, bool backCompatibility = false)
		{
			if (backCompatibility)
				AppContext.SetSwitch("Npgsql.EnableStoredProcedureCompatMode", true);

			builder.Services.Configure(configure);
			builder.AddConfiguration();
			builder.Services.TryAddSingleton<IPostgreLoggerRootFactory, PostgreClassicLoggerRootFactory>();
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, PostgreLogProvider>());
			LoggerProviderOptions.RegisterProviderOptions<PostgreLoggerProviderOptions, PostgreLogProvider>(builder.Services);
			LoggerProviderOptions.RegisterProviderOptions<NpgsqlConnectionStringBuilder, PostgreLogProvider>(builder.Services);
			return builder;
		}

		/// <summary>
		/// Uses classic read-while-write logger implementation.
		/// </summary>
		public static ILoggingBuilder UseClassic(this ILoggingBuilder builder)
		{
			builder.Services.RemoveAll<IPostgreLoggerRootFactory>();
			builder.Services.AddSingleton<IPostgreLoggerRootFactory, PostgreClassicLoggerRootFactory>();
			return builder;
		}

		/// <summary>
		/// Uses auto-wait logger implementation.
		/// </summary>
		public static ILoggingBuilder UseAutoWait(this ILoggingBuilder builder)
		{
			builder.Services.RemoveAll<IPostgreLoggerRootFactory>();
			builder.Services.AddSingleton<IPostgreLoggerRootFactory, PostgreAutoWaitLoggerRootFactory>();
			return builder;
		}
	}
}


