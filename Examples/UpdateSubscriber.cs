using PP.Integrator.ChangeTracking;

namespace Examples
{
	public class UpdateSubscriber : BackgroundService
	{
		private readonly ILogger<UpdateSubscriber> logger;
		private readonly IChangeDispatcher dispatcher;
		EventTriggerExample settings;
		public UpdateSubscriber(ILogger<UpdateSubscriber> logger, IChangeDispatcher dispatcher)
		{
			this.logger = logger;
			this.dispatcher = dispatcher;
			settings = new EventTriggerExample();
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
