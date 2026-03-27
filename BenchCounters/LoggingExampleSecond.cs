namespace BenchCounters;

public class LoggingExampleSecond : BackgroundService
{
	private ILogger<Status> statusLogger;
	private ILogger<Project> projectLogger;
	private readonly ILogger<LoggingExampleSecond> _log3;
	private int inta;

	public LoggingExampleSecond(ILogger<Status> log, ILogger<Project> log2, ILogger<LoggingExampleSecond> log3)
	{
		statusLogger = log;
		projectLogger = log2;
		_log3 = log3;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		LogLevel level = LogLevel.Debug;
		inta = 0;
		var exc = new ArgumentNullException(nameof(stoppingToken));
		await Task.CompletedTask;
		try
		{
			using var backgroundScope = statusLogger.BeginScope("status");
			using var projectScope = projectLogger.BeginScope("project");
			var finishAt = DateTime.UtcNow.AddMinutes(1);

			while (DateTime.UtcNow < finishAt && !stoppingToken.IsCancellationRequested)
			{
				level = (LogLevel)(inta++ % 6);

				var logEntry = new Status
				{
					Name = "Active",
					Display = "Активен",
					Version = inta,
					Description = "Описание статуса",
					Order = inta % 5
				};

				var projEntry = new Project
				{
					Name = "Test writting" + inta,
					Description = "проект номер " + inta,
					Version = inta,
					LeftHours = inta * 3
				};

				//statusLogger.Log(level, inta, logEntry, level >= LogLevel.Error ? exc : default, (item, err) => "Loglevel");
				if (level >= LogLevel.Error)
					_log3.Log(level, exc, "Ошибка статуса {Status}", logEntry);

				statusLogger.LogInformation(inta, "Status {Name} ({Display}) updated version {Version} with order {Order}", logEntry.Name, logEntry.Display, logEntry.Version, logEntry.Order);
				projectLogger.LogInformation(inta + 1, "Проект {Name} ({Description}) изменил версию на: {Version} с остатком часов: {LeftHours}", projEntry.Name, projEntry.Description, projEntry.Version, projEntry.LeftHours);
			}
		}
		catch (Exception err)
		{
			statusLogger.LogError(err, "log error");
		}

		Console.WriteLine(nameof(LoggingExampleSecond) + " Logging completed" + inta);
	}

	public record Status
	{
		public string Name { get; set; }
		public string Display { get; set; }
		public int Version { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
	}

	public record Project
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
		public int Version { get; set; }
		public double LeftHours { get; set; }
	}
}
