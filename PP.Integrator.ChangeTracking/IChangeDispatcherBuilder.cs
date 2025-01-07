namespace PP.Integrator.ChangeTracking
{
	/// <summary>
	/// Интерфейс класса билдера для настроки прослушивания изменений
	/// </summary>
	public interface IChangeDispatcherBuilder
	{
		/// <summary>
		/// Отслеживать изменения для типа <typeparamref name="Item"/>
		/// </summary>
		/// <typeparam name="Item"></typeparam>
		/// <returns></returns>
		IChangeDispatcherBuilder TrackChangesOf<Item>() where Item : class;
	}
}
