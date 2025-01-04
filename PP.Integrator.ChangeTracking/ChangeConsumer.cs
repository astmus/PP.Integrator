namespace PP.Integrator.ChangeTracking
{
	public abstract class ChangeConsumer<Item> : IObserver<ChangeItemInfo<Item>> where Item : class
	{
		protected ChangeItemInfo<Item> ItemInfo { get; set; } = null!;
		public abstract void OnCompleted();
		public abstract void OnError(Exception error);
		public abstract void OnCreate(Item item);
		public abstract void OnDelete(Item deleted);
		public abstract void OnUpdate(Item current, Item old);

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
