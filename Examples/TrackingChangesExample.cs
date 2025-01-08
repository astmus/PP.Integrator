using PP.Integrator.ChangeTracking;

namespace Examples
{
	public class TrackingChangesExample : BackgroundService
	{
		private readonly ILogger<TrackingChangesExample> logger;
		private readonly IChangeDispatcher dispatcher;
		EventTriggerListener settings;
		public TrackingChangesExample(ILogger<TrackingChangesExample> logger, IChangeDispatcher dispatcher)
		{
			this.logger = logger;
			this.dispatcher = dispatcher;
			settings = new EventTriggerListener();
		}
		public override Task StartAsync(CancellationToken cancellationToken)
		{
			var triggerChangesProvider = dispatcher.ChangesOf<EventTrigger>();
			return base.StartAsync(cancellationToken);
		}
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var triggerChangesProvider = dispatcher.ChangesOf<EventTrigger>();
			using var subscribe = triggerChangesProvider.Subscribe(settings);

			while (!stoppingToken.IsCancellationRequested)
			{
				if (logger.IsEnabled(LogLevel.Information))
				{
					logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
				}
				await Task.Delay(1000, stoppingToken);
			}
		}
	}
}
