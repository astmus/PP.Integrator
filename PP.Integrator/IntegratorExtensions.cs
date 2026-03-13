using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Npgsql;
using PP.Integrator.Logging;

namespace PP.Integrator
{
	/// <summary>
	/// Регистрация NpgsqlDataSource и bulk-логирования в Postgre.
	/// </summary>
	public static class IntegratorLoggerExtensions
	{
		/// <summary>
		/// Регистрирует <see cref="NpgsqlDataSource" /> в контейнере для использования логгером.
		/// </summary>
		/// <param name="services">Коллекция сервисов.</param>
		/// <param name="configure">Настройка строки подключения.</param>
		/// <returns></returns>
		public static IServiceCollection AddPostgreLoggingDataSource(this IServiceCollection services, Action<NpgsqlConnectionStringBuilder> configure)
		{
			var csb = new NpgsqlConnectionStringBuilder();
			configure(csb);
			var dataSource = NpgsqlDataSource.Create(csb);
			services.AddSingleton(dataSource);
			return services;
		}

		/// <summary>
		/// Добавляет bulk-логирование в Postgre. Требует зарегистрированный <see cref="NpgsqlDataSource" /> (например, через <see cref="AddPostgreLoggingDataSource" />).
		/// </summary>
		/// <param name="builder">Построитель логирования.</param>
		/// <param name="backCompatibility">True если нужна обратная совместимость.</param>
		/// <returns></returns>
		public static ILoggingBuilder AddPostgreLogger(this ILoggingBuilder builder, bool backCompatibility = false)
		{
			if (backCompatibility)
				AppContext.SetSwitch("Npgsql.EnableStoredProcedureCompatMode", true);

			builder.AddConfiguration();
			builder.Services.TryAddSingleton<IPostgreLoggerRootFactory, PostgreClassicLoggerRootFactory>();
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, PostgreLogProvider>());
			LoggerProviderOptions.RegisterProviderOptions<PostgreLoggerProviderOptions, PostgreLogProvider>(builder.Services);
			return builder;
		}

		/// <summary>
		/// Регистрирует <see cref="NpgsqlDataSource" /> в контейнере и добавляет bulk-логирование в Postgre.
		/// </summary>
		/// <param name="builder">Построитель логирования.</param>
		/// <param name="configure">Настройка строки подключения.</param>
		/// <param name="backCompatibility">True если нужна обратная совместимость.</param>
		/// <returns></returns>
		public static ILoggingBuilder AddPostgreLogger(this ILoggingBuilder builder, Action<NpgsqlConnectionStringBuilder> configure, bool backCompatibility = false)
		{
			builder.Services.AddPostgreLoggingDataSource(configure);
			return builder.AddPostgreLogger(backCompatibility);
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


