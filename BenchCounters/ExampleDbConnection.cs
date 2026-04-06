using Npgsql;

namespace BenchCounters;

internal static class ExampleDbConnection
{
	public static void Configure(NpgsqlConnectionStringBuilder builder)
	{
		builder.Host = "localhost";
		builder.Port = 5432;
		builder.Database = "postgres";
		builder.Username = "postgres";
		builder.Password = "postgres";
		builder.CommandTimeout = 600;
		//builder.ConnectionIdleLifetime = 10;
		//builder.ConnectionPruningInterval = 10;
		builder.Enlist = false;

		builder.MaxAutoPrepare = 200;
		builder.AutoPrepareMinUsages = 2;
		builder.WriteBufferSize = 65536;
		builder.Pooling = true;
		builder.MinPoolSize = 2;
		builder.MaxPoolSize = 32;
	}
}
