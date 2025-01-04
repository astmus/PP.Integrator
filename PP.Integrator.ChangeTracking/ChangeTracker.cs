using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;

namespace PP.Integrator.ChangeTracking
{
	internal class ChangeTracker : BackgroundService
	{		
		private readonly ILogger<ChangeTracker> log;
		private readonly ChangeDispatcher dispatcher;
		private readonly NpgsqlConnection connection;
		private readonly IOptionsMonitor<NpgsqlConnectionStringBuilder> monitor;

		public ChangeTracker(IOptionsMonitor<NpgsqlConnectionStringBuilder> monitor, ILogger<ChangeTracker> log, ChangeDispatcher dispatcher)
		{
			this.monitor = monitor;			
			this.log = log;
			this.dispatcher = dispatcher;

			monitor.CurrentValue.KeepAlive = 4;
			monitor.CurrentValue.IncludeErrorDetail = true;
			monitor.CurrentValue.Enlist = false;
			connection = new NpgsqlConnection(monitor.CurrentValue.ConnectionString);			
		}

		public override async Task StartAsync(CancellationToken cancellationToken)
		{
			await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
			await dispatcher.StartListenAsync(connection, cancellationToken).ConfigureAwait(false);
			connection.Notice += OnNotice;
			connection.Notification += OnNotification;
			await base.StartAsync(cancellationToken).ConfigureAwait(false);
		}

		protected override async Task ExecuteAsync(CancellationToken cancellationToken)
		{
			do
				try
				{
					await connection.WaitAsync(cancellationToken).ConfigureAwait(false);
				}
				catch (Exception error)
				{
					log.LogError("WaitAsync: {Error}", error);
				}
			while (!cancellationToken.IsCancellationRequested);
		}

		private void OnNotification(object sender, NpgsqlNotificationEventArgs e)
		{
			try
			{
				dispatcher.Dispatch(e.Channel, e.Payload);				
			}
			catch (Exception error)
			{
				log.LogError("OnNotification: {Error}", error);
			}
		}

		void OnNotice(object sender, NpgsqlNoticeEventArgs e)
			=> log.LogInformation("OnNotice: {Notice}", e.Notice.MessageText);

		public override async Task StopAsync(CancellationToken cancellationToken)
		{
			await connection.CloseAsync();
			await base.StopAsync(cancellationToken);
		}		
	}
}
