namespace BenchCounters;

public class LoggingExampleSecond : BackgroundService
{
	private ILogger<Status> statusLogger;
	private ILogger<Project> projectLogger;
	public int inta = 0;

	public LoggingExampleSecond(ILogger<Status> log, ILogger<Project> log2)
	{
		statusLogger = log;
		projectLogger = log2;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		LogLevel level = LogLevel.Debug;
		inta = 0;
		var exc = new ArgumentNullException(nameof(stoppingToken));
		try
		{
			using var backgroundScope = statusLogger.BeginScope("statuslogs");
			using var projectScope = projectLogger.BeginScope("projectlogs");

			for (int i = 0; i < 300; i++)
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

				await Task.Delay(101);
				//statusLogger.Log(level, inta, logEntry, level >= LogLevel.Error ? exc : default, (item, err) => "Loglevel");
				if (level >= LogLevel.Error)
					statusLogger.Log(level, exc, "Ошибка статуса {Status}", logEntry);

				statusLogger.LogInformation(inta, "Status {Name} ({Display}) updated version {Version} with order {Order}", logEntry.Name, logEntry.Display, logEntry.Version, logEntry.Order);
				projectLogger.LogInformation(inta + 1, "Проект {Name} ({Description}) изменил версию на: {Version} с остатком часов: {LeftHours}", projEntry.Name, projEntry.Description, projEntry.Version, projEntry.LeftHours);
			}
		}
		catch (Exception err)
		{
			statusLogger.LogError(err.Message, err);
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
