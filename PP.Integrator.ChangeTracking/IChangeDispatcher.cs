#nullable disable
namespace PP.Integrator.ChangeTracking
{
	/// <summary>
	/// Интервейс диспетчера изменений
	/// </summary>
	public interface IChangeDispatcher
	{
		/// <summary>
		/// Возвращает провайдер изменений для типа <typeparamref name="Item"/>
		/// </summary>
		/// <typeparam name="Item"></typeparam>
		/// <returns></returns>
		IObservable<ChangeItemInfo<Item>> ChangesOf<Item>() where Item : class;
	}	
}
#nullable restore