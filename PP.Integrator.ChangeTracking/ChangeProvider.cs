using System.Text.Json;
using System.Text.Json.Serialization;

namespace PP.Integrator.ChangeTracking
{
	/// <summary>
	/// Класс обеспецивающий доставку уведомлений об изменениях данных
	/// </summary>
	/// <typeparam name="Item"></typeparam>
	public class ChangeProvider<Item> : IObservable<ChangeItemInfo<Item>>, IChangeProvider where Item : class
	{
		private readonly List<IObserver<ChangeItemInfo<Item>>> observers;
		/// <summary>
		/// 
		/// </summary>
		public ChangeProvider()
		{
			observers = new List<IObserver<ChangeItemInfo<Item>>>();
		}

		/// <summary>
		/// Уведомляет поставщика о том, что наблюдатель должен получать уведомления.
		/// </summary>
		/// <param name="observer">Объект, который должен получать уведомления.</param>
		/// <returns>Ссылка на интерфейс, позволяющий наблюдателям прекратить получение уведомлений до того, как поставщик завершит их отправку.</returns>
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

		/// <summary>
		/// Передает информацию об изменениях всем наблюдателям
		/// </summary>
		/// <param name="changes"></param>
		public void Provide(string changes)
		{
			if (JsonSerializer.Deserialize<ChangeItemInfo<Item>>(changes, options) is not ChangeItemInfo<Item> item)
				return;

			foreach (var observer in observers)
				observer.OnNext(item);

			//if (item.Error)
			//	observer.OnError(item.Error);			
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
