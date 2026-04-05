namespace BenchCounters;

public class LoggingExampleTwoScopes : BackgroundService
{
	private readonly ILogger<LoggingExampleTwoScopes> logger;
	public int Inta { get; private set; }

	public LoggingExampleTwoScopes(ILogger<LoggingExampleTwoScopes> logger)
	{
		this.logger = logger;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		LogLevel level = LogLevel.Debug;
		var finishAt = DateTime.UtcNow.AddSeconds(60);
		Inta = 0;
		var exc = new ArgumentNullException(nameof(stoppingToken));

		await Task.Yield();

		try
		{
			using var firstScope = logger.BeginScope("firstScope");
			using var secondScope = logger.BeginScope("secondScope");

			while (DateTime.UtcNow < finishAt && !stoppingToken.IsCancellationRequested)
			{
				level = (LogLevel)(Inta++ % 5);
				logger.Log(level, exc, "Two scopes message {Iteration}", Inta);
			}
		}
		catch (Exception err)
		{
			logger.LogError(err, "Ошибка в LoggingExampleTwoScopes");
		}

	}
}
