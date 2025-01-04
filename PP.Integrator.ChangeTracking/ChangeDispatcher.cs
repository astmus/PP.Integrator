using Npgsql;
#nullable disable
namespace PP.Integrator.ChangeTracking
{
	internal class ChangeDispatcher : IChangeDispatcher
	{		
		IReadOnlyDictionary<string, Box> trackingTypes;

		public ChangeDispatcher(IReadOnlyDictionary<string, Box> trackingTypes)
		{
			this.trackingTypes = trackingTypes;
		}

		public async Task StartListenAsync(NpgsqlConnection connection, CancellationToken cancel)
		{
			if (connection.State != System.Data.ConnectionState.Open)
				await connection.OpenAsync(cancel).ConfigureAwait(false);

			foreach (var typeName in trackingTypes.Keys)
			{
				NpgsqlCommand cmd = new NpgsqlCommand("LISTEN " + typeName, connection);
				await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
			}
		}

		public void Dispatch(string name, string changes)
		{
			if (trackingTypes.TryGetValue(name, out Box box) && box.GetValue(out IChangeProvider provider))
				provider.Provide(changes);
		}

		public IObservable<ChangeItemInfo<Item>> ChangesOf<Item>() where Item : class
		{			
			if (trackingTypes.TryGetValue(TypeHelper<Item>.Name, out Box box))
				return box.GetValue<IObservable<ChangeItemInfo<Item>>>();

			return null;
		}
	}
}
#nullable restore