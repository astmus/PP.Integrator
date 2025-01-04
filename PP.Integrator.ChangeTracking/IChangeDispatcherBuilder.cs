namespace PP.Integrator.ChangeTracking
{
	public interface IChangeDispatcherBuilder
	{
		IChangeDispatcherBuilder TrackChangesOf<Item>() where Item : class;
	}
}
