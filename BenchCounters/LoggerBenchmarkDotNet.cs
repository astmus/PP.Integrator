using BenchmarkDotNet.Attributes;
using Npgsql;
using PP.Integrator;

namespace BenchCounters;

[MemoryDiagnoser]
public class LoggerBenchmarkDotNet
{
	private const string DataFlowTableName = "logs.dataflow";

	private IDisposable _scope = default!;
	private ILogger _logger = default!;
	private ILoggerFactory _factory = default!;
	private BenchmarkPayload[] _payloads = default!;

	[Params(10_000)]
	public int Operations { get; set; }

	[Benchmark(Baseline = true)]
	public void DataFlow()
	{
		for (var i = 0; i < Operations; i++)
		{
			var payload = _payloads[i & 63];
			_logger.LogInformation("BDN dataflow payload {PayloadId} tags {TagsCount} checksum {Checksum} details {Payload}", payload.Id, payload.Tags.Length, payload.Checksum, payload);
		}
	}

	[GlobalCleanup]
	public void Cleanup()
	{
		_scope.Dispose();
		_factory.Dispose();
	}

	[GlobalSetup]
	public void Setup()
	{
		TruncateBenchmarkTable();
		_factory = LoggerFactory.Create(builder =>
		{
			builder.ClearProviders();
			builder.AddPostgreLogger(ExampleDbConnection.Configure);
		});

		_logger = _factory.CreateLogger("bdn-dataflow");
		_scope = _logger.BeginScope("dataflow");
		_payloads = Enumerable.Range(0, 64).Select(BenchmarkPayload.Create).ToArray();
	}

	private static void TruncateBenchmarkTable()
	{
		var csb = new NpgsqlConnectionStringBuilder();
		ExampleDbConnection.Configure(csb);

		using var connection = new NpgsqlConnection(csb.ConnectionString);
		connection.Open();

		if (!TableExists(connection, DataFlowTableName))
			return;

		using var truncateCommand = connection.CreateCommand();
		truncateCommand.CommandText = $"TRUNCATE TABLE {DataFlowTableName}";
		truncateCommand.ExecuteNonQuery();
	}

	private static bool TableExists(NpgsqlConnection connection, string tableName)
	{
		using var existsCommand = connection.CreateCommand();
		existsCommand.CommandText = "SELECT to_regclass(@table_name)::text";
		existsCommand.Parameters.AddWithValue("table_name", tableName);
		return existsCommand.ExecuteScalar() is string;
	}
}
