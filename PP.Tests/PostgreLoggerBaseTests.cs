using Microsoft.Extensions.Logging;
using Npgsql;
using PP.Integrator.Logging;

namespace PP.Tests;

public class PostgreLoggerBaseTests
{
	[Fact]
	public async Task ExecuteWithRetryAsync_MustRetryTransientError_AndEventuallySucceed()
	{
		var logger = new RetrySpyLogger();
		var attempts = 0;

		await logger.ExecuteWithRetryAsync(() =>
		{
			attempts++;
			if (attempts < 3)
				throw new TimeoutException("transient");

			return Task.CompletedTask;
		});

		Assert.Equal(3, attempts);
	}

	[Fact]
	public async Task ExecuteWithRetryAsync_MustNotRetryNonTransientError()
	{
		var logger = new RetrySpyLogger();
		var attempts = 0;

		await Assert.ThrowsAsync<InvalidOperationException>(() =>
			logger.ExecuteWithRetryAsync(() =>
			{
				attempts++;
				throw new InvalidOperationException("fatal");
			}));

		Assert.Equal(1, attempts);
	}

	private sealed class RetrySpyLogger : PostgreLoggerBase
	{
		public RetrySpyLogger()
			: base(
				"Tests.Retry",
				NpgsqlDataSource.Create(new NpgsqlConnectionStringBuilder { Host = "localhost", Database = "test" }),
				new PostgreLoggerProviderOptions { WriteRetryCount = 3 },
				LogLevel.Trace)
		{
		}

		public Task ExecuteWithRetryAsync(Func<Task> operation) =>
			base.ExecuteWithRetryAsync(nameof(RetrySpyLogger), "logs.test_log", operation);

		protected override void InitializeCore()
		{
		}

		protected override void EnqueueEntry(LogRecord entry)
		{
		}

		public override void Flush()
		{
		}
	}
}
