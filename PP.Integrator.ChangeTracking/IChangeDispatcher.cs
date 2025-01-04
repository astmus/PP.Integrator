#nullable disable
namespace PP.Integrator.ChangeTracking
{
	public interface IChangeDispatcher
	{
		IObservable<ChangeItemInfo<Item>> ChangesOf<Item>() where Item : class;
	}	
}
#nullable restore