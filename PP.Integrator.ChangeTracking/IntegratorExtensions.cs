using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace PP.Integrator.ChangeTracking
{
	/// <summary>
	/// Класс расширений
	/// </summary>
	public static class IntegratorExtensions
	{
		/// <summary>
		/// Добавляет в приложени поддержку активного прослушивания изменений объектов в базе данных
		/// </summary>
		/// <param name="services">Коллекция сервисов</param>
		/// <param name="configure">Настройка подключнения к базе данных</param>
		/// <param name="configureBuilder">Настройка прослушивания изменений</param>
		/// <returns></returns>
		public static IServiceCollection AddPostgreChangeTrackingService(this IServiceCollection services, Action<NpgsqlConnectionStringBuilder> configure, Action<IChangeDispatcherBuilder> configureBuilder)
		{
			services.Configure(configure);
			services.AddHostedService<ChangeTracker>();
			services.AddOptions<NpgsqlConnectionStringBuilder>();
			services.AddSingleton<ChangeDispatcher>(sp =>
			{
				ChangeDispatcherBuilder builder = new ChangeDispatcherBuilder();
				configureBuilder(builder);
				return builder.Build();
			}).
			AddSingleton<IChangeDispatcher>(sp => sp.GetRequiredService<ChangeDispatcher>());

			return services;
		}
	}
}


