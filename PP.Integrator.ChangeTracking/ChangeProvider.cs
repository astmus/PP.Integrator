using System.Text.Json;
using System.Text.Json.Serialization;

namespace PP.Integrator.ChangeTracking
{
	public class ChangeProvider<Item> : IObservable<ChangeItemInfo<Item>>, IChangeProvider where Item : class
	{
		private readonly List<IObserver<ChangeItemInfo<Item>>> observers;
		public ChangeProvider()
		{
			observers = new List<IObserver<ChangeItemInfo<Item>>>();
		}

		public IDisposable Subscribe(IObserver<ChangeItemInfo<Item>> observer)
		{
			if (!observers.Contains(observer))
				observers.Add(observer);

			return new Unsubscriber(observers, observer);
		}

		private class Unsubscriber : IDisposable
		{
			private List<IObserver<ChangeItemInfo<Item>>> observers;
			private IObserver<ChangeItemInfo<Item>> observer;

			public Unsubscriber(List<IObserver<ChangeItemInfo<Item>>> observers, IObserver<ChangeItemInfo<Item>> observer)
			{
				this.observers = observers;
				this.observer = observer;
			}

			public void Dispose()
			{
				if (observer != null && observers.Contains(observer))
					observers.Remove(observer);
			}
		}


		public void Provide(string changes)
		{
			if (JsonSerializer.Deserialize<ChangeItemInfo<Item>>(changes, options) is not ChangeItemInfo<Item> item)
				return;

			foreach (var observer in observers)
				observer.OnNext(item);

			//if (item.Error)
			//	observer.OnError(item.Error);
			//else			
		}

		static readonly JsonSerializerOptions options = new JsonSerializerOptions()
		{
			PropertyNameCaseInsensitive = true,					
			Converters =
			{
				new JsonStringEnumConverter()
			}
		};
	}
}
