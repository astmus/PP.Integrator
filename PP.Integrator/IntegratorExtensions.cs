using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Npgsql;
using PP.Integrator.Logging;
using PP.Shared.Extensions;

namespace PP.Integrator;

/// <summary>
/// Класс-расширение для регистрации логгера
/// </summary>
public static class IntegratorLoggerExtensions
{
	private const string STORED_PROCEDURE_COMPAT_MODE_SWITCH = "Npgsql.EnableStoredProcedureCompatMode";

	/// <summary>
	/// Регистрирует источник данных Postgre, используемый только инфраструктурой логирования.
	/// Если источник уже зарегистрирован, повторная регистрация не выполняется.
	/// </summary>
	public static IServiceCollection AddPostgreLoggingDataSource(this IServiceCollection services, Action<NpgsqlConnectionStringBuilder> configure)
	{
		GuardEx.ThrowIfNull(services, nameof(services));
		GuardEx.ThrowIfNull(configure, nameof(configure));

		services.TryAddSingleton<IPostgreLoggingDataSourceAccessor>(_ =>
		{
			return new PostgreLoggingDataSourceAccessor(() =>
			{
				var csb = new NpgsqlConnectionStringBuilder();
				configure(csb);
				return new NpgsqlDataSourceBuilder(csb.ConnectionString).Build();
			});
		});

		return services;
	}

	/// <summary>
	/// Регистрирует источник данных Postgre, используемый только инфраструктурой логирования.
	/// Позволяет настроить <see cref="NpgsqlDataSourceBuilder" /> напрямую.
	/// </summary>
	public static IServiceCollection AddPostgreLoggingDataSource(this IServiceCollection services, string connectionString, Action<NpgsqlDataSourceBuilder>? configure = null)
	{
		GuardEx.ThrowIfNull(services, nameof(services));
		GuardEx.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));

		services.TryAddSingleton<IPostgreLoggingDataSourceAccessor>(_ =>
		{
			return new PostgreLoggingDataSourceAccessor(() =>
			{
				var builder = new NpgsqlDataSourceBuilder(connectionString);
				configure?.Invoke(builder);
				return builder.Build();
			});
		});

		return services;
	}

	/// <summary>
	/// Добавляет Postgre-провайдер логирования.
	/// Требует зарегистрированный <see cref="IPostgreLoggingDataSourceAccessor" />.
	/// </summary>
	public static ILoggingBuilder AddPostgreLogger(this ILoggingBuilder builder, bool backCompatibility = false)
	{
		GuardEx.ThrowIfNull(builder, nameof(builder));

		ApplyBackCompatibility(backCompatibility);
		AddPostgreLoggerCore(builder);
		return builder;
	}

	/// <summary>
	/// Регистрирует источник данных Postgre и добавляет Postgre-провайдер логирования.
	/// </summary>
	public static ILoggingBuilder AddPostgreLogger(this ILoggingBuilder builder, Action<NpgsqlConnectionStringBuilder> configure, bool backCompatibility = false)
	{
		GuardEx.ThrowIfNull(builder, nameof(builder));
		GuardEx.ThrowIfNull(configure, nameof(configure));

		ApplyBackCompatibility(backCompatibility);
		builder.Services.AddPostgreLoggingDataSource(configure);
		AddPostgreLoggerCore(builder);
		return builder;
	}

	/// <summary>
	/// Регистрирует источник данных Postgre и добавляет Postgre-провайдер логирования.
	/// Позволяет настроить <see cref="NpgsqlDataSourceBuilder" /> напрямую.
	/// </summary>
	public static ILoggingBuilder AddPostgreLogger(this ILoggingBuilder builder, string connectionString, Action<NpgsqlDataSourceBuilder>? configure = null, bool backCompatibility = false)
	{
		GuardEx.ThrowIfNull(builder, nameof(builder));
		GuardEx.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));

		ApplyBackCompatibility(backCompatibility);
		builder.Services.AddPostgreLoggingDataSource(connectionString, configure);
		AddPostgreLoggerCore(builder);
		return builder;
	}

	/// <summary>
	/// Добавляет фильтр для Postgre-провайдера логирования.
	/// </summary>
	public static ILoggingBuilder AddPostgreLoggerFilter(this ILoggingBuilder builder, string? category, LogLevel minLevel)
	{
		GuardEx.ThrowIfNull(builder, nameof(builder));

		builder.AddFilter<PostgreLogProvider>(category, minLevel);
		return builder;
	}

	/// <summary>
	/// Использует классическую реализацию логгера.
	/// </summary>
	public static ILoggingBuilder UseClassic(this ILoggingBuilder builder)
	{
		GuardEx.ThrowIfNull(builder, nameof(builder));

		builder.Services.RemoveAll<IPostgreLoggerRootFactory>();
		builder.Services.AddSingleton<IPostgreLoggerRootFactory, PostgreClassicLoggerRootFactory>();
		return builder;
	}

	/// <summary>
	/// Использует реализацию логгера с auto-wait.
	/// </summary>
	public static ILoggingBuilder UseAutoWait(this ILoggingBuilder builder)
	{
		GuardEx.ThrowIfNull(builder, nameof(builder));

		builder.Services.RemoveAll<IPostgreLoggerRootFactory>();
		builder.Services.AddSingleton<IPostgreLoggerRootFactory, PostgreAutoWaitLoggerRootFactory>();
		return builder;
	}

	private static void ApplyBackCompatibility(bool backCompatibility)
	{
		if (!backCompatibility)
			return;

		AppContext.SetSwitch(STORED_PROCEDURE_COMPAT_MODE_SWITCH, true);
	}

	private static void AddPostgreLoggerCore(ILoggingBuilder builder)
	{
		builder.AddConfiguration();
		builder.Services.TryAddSingleton<IPostgreLoggerRootFactory, PostgreClassicLoggerRootFactory>();
		builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, PostgreLogProvider>());
		LoggerProviderOptions.RegisterProviderOptions<PostgreLoggerProviderOptions, PostgreLogProvider>(builder.Services);
	}
}
