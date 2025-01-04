using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace PP.Integrator.ChangeTracking
{
	public static class IntegratorExtensions
	{
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


