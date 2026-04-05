using Npgsql;
using PP.Integrator.Logging;

namespace PP.Tests;

public class PostgreLoggerTests
{
	[Fact]
	public void WriteEntry_MustInitializeOnce_AndEnqueueEntries()
	{
		using var logger = new SpyLogger();
		var entry1 = CreateEntry("first");
		var entry2 = CreateEntry("second");

		logger.WriteEntry(entry1);
		logger.WriteEntry(entry2);

		Assert.Equal(1, logger.InitializeCalls);
		Assert.Equal(2, logger.EnqueueCalls);
	}

	[Fact]
	public void WriteEntry_AfterDispose_MustNotEnqueue()
	{
		var logger = new SpyLogger();
		logger.Dispose();

		logger.WriteEntry(CreateEntry("ignored"));

		Assert.Equal(0, logger.EnqueueCalls);
		Assert.Equal(1, logger.DisposeCalls);
	}

	private static LogRecord<string> CreateEntry(string state) =>
		new(
			new LogEntry<string>(
				Microsoft.Extensions.Logging.LogLevel.Information,
				"Tests.Retry",
				new Microsoft.Extensions.Logging.EventId(1, "evt"),
				state,
				null,
				static (s, _) => s),
			"logs.test_log");

	private sealed class SpyLogger : PostgreLogger
	{
		public SpyLogger()
			: base(new TestDataSourceAccessor(), new PostgreLoggerProviderOptions())
		{
		}

		public int InitializeCalls { get; private set; }
		public int EnqueueCalls { get; private set; }
		public int DisposeCalls { get; private set; }

		protected override void Initialize()
		{
			InitializeCalls++;
		}

		protected override void EnqueueEntry(LogRecord entry)
		{
			EnqueueCalls++;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			DisposeCalls++;
		}
	}

	private sealed class TestDataSourceAccessor : IPostgreLoggingDataSourceAccessor
	{
		public NpgsqlDataSource DataSource { get; } =
			NpgsqlDataSource.Create(new NpgsqlConnectionStringBuilder { Host = "localhost", Database = "test" }.ConnectionString);
	}
}
