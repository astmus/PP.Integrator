using PP.Integrator.ChangeTracking;

namespace BenchCounters;

public class TrackingChangesExample : BackgroundService
{
	private readonly IChangeDispatcher dispatcher;
	private readonly ILogger<TrackingChangesExample> logger;
	private readonly EventTriggerListener settings;

	public TrackingChangesExample(ILogger<TrackingChangesExample> logger, IChangeDispatcher dispatcher)
	{
		this.dispatcher = dispatcher;
		this.logger = logger;
		settings = new EventTriggerListener();
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		var triggerChangesProvider = dispatcher.ChangesOf<EventTrigger>();
		using var subscribe = triggerChangesProvider.Subscribe(settings);

		while (!stoppingToken.IsCancellationRequested)
		{
			if (logger.IsEnabled(LogLevel.Information))
				logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

			await Task.Delay(1000, stoppingToken);
		}
	}

	public override Task StartAsync(CancellationToken cancellationToken)
	{
		_ = dispatcher.ChangesOf<EventTrigger>();
		return base.StartAsync(cancellationToken);
	}
}
