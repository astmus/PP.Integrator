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
		/// <typeparam name="Item">Тип отслеживаемой сущности.</typeparam>
		/// <returns>Поток уведомлений об изменениях для указанного типа.</returns>
		IObservable<ChangeItemInfo<Item>> ChangesOf<Item>() where Item : class;
	}	
}
#nullable restore
