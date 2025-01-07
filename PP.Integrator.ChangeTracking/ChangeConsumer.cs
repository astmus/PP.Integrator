namespace PP.Integrator.ChangeTracking
{
	/// <summary>
	/// Базовый класс для получения и обработки изменений которые произошли с объектом типа <typeparamref name="Item"/>
	/// </summary>
	/// <typeparam name="Item"></typeparam>
	public abstract class ChangeConsumer<Item> : IObserver<ChangeItemInfo<Item>> where Item : class
	{
		/// <summary>
		/// Содержит информацию об ихзменениях
		/// </summary>
		protected ChangeItemInfo<Item> ItemInfo { get; set; } = null!;

		/// <summary>
		/// Уведомляет наблюдателя о том, что поставщик завершил отправку уведомлений.
		/// </summary>
		public abstract void OnCompleted();

		/// <summary>
		/// Уведомляет наблюдателя о том, что у поставщика возникла ошибка.
		/// </summary>
		/// <param name="error"></param>
		public abstract void OnError(Exception error);

		/// <summary>
		/// Уведомляет наблюдателя о том, поставщик получил информацию о создании объекта.
		/// </summary>
		/// <param name="created">Созданный объект</param>
		public abstract void OnCreate(Item created);

		/// <summary>
		/// Уведомляет наблюдателя о том, поставщик получил информацию об удалении объекта.
		/// </summary>
		/// <param name="deleted"></param>
		public abstract void OnDelete(Item deleted);

		/// <summary>
		/// Уведомляет наблюдателя о том, поставщик получил информацию о изменении объекта.
		/// </summary>
		/// <param name="current"></param>
		/// <param name="old"></param>
		public abstract void OnUpdate(Item current, Item old);

		/// <summary>
		/// Предоставляет наблюдателю новые данные.
		/// </summary>
		/// <param name="value">Содержит информацию об ихзменениях</param>
		public virtual void OnNext(ChangeItemInfo<Item> value)
		{
			ItemInfo = value;
			switch (value.Action)
			{
				case ChangeKind.Update:
				OnUpdate(value.New, value.Old);
				break;
				case ChangeKind.Insert:
				OnCreate(value.New);
				break;
				case ChangeKind.Delete:
				OnDelete(value.Old);
				break;
			}
		}
	}
}
