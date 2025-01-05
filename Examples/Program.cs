using Npgsql;
using PP.Integrator;
using PP.Integrator.ChangeTracking;

namespace Examples
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = Host.CreateApplicationBuilder();
			//builder.Logging.ClearProviders();
			builder.Logging.AddPostgreLogger(ConfigureConnectionString);
			builder.Services.AddLoggingExamples();
			
			//builder.Services.AddHostedService<TrackingChangesExample>();
			//builder.Services.AddPostgreChangeTrackingService(ConfigureConnectionString, ConfigureTracking);
			
			var host = builder.Build();
			host.Run();
		}

		static void ConfigureTracking(IChangeDispatcherBuilder builder)
		{
			builder.TrackChangesOf<EventTrigger>();
		}

		static void ConfigureConnectionString(NpgsqlConnectionStringBuilder builder)
		{
			builder.Host = "localhost";
			builder.Port = 5432;
			builder.Database = "master";
			builder.Password = "docker";
			builder.Username = "docker";
#if DEBUG
			builder.IncludeErrorDetail = true;
#endif
			builder.ConnectionIdleLifetime = 10;
			builder.ConnectionPruningInterval = 10;
			builder.Enlist = false;
		}
	}
}