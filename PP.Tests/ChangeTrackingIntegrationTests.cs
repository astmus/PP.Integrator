using PP.Integrator.ChangeTracking;

namespace PP.Tests;

public class ChangeTrackingIntegrationTests
{
	[Fact]
	public void ChangeProvider_DisposedSubscription_MustStopNotifications()
	{
		var provider = new ChangeProvider<TestItem>();
		var observer = new TestObserver();
		using var subscription = provider.Subscribe(observer);

		provider.Provide(@"{
				""Timestamp"": ""2026-03-14T00:00:00Z"",
				""Action"": ""Insert"",
				""DataBase"": ""logs"",
				""Schema"": ""public"",
				""Table"": ""items"",
				""New"": {
					""Id"": 1
				},
				""Old"": null
			}");

		subscription.Dispose();
		provider.Provide(@"{
				""Timestamp"": ""2026-03-14T00:00:01Z"",
				""Action"": ""Insert"",
				""DataBase"": ""logs"",
				""Schema"": ""public"",
				""Table"": ""items"",
				""New"": {
					""Id"": 2
				},
				""Old"": null
			}");

		var change = Assert.Single(observer.Received);
		Assert.Equal(1, change.New.Id);
	}

	private sealed class TestObserver : IObserver<ChangeItemInfo<TestItem>>
	{
		public List<ChangeItemInfo<TestItem>> Received { get; } = new();

		public void OnCompleted()
		{
		}

		public void OnError(Exception error)
		{
		}

		public void OnNext(ChangeItemInfo<TestItem> value)
		{
			Received.Add(value);
		}
	}

	private sealed class TestItem
	{
		public int Id { get; set; }
	}
}
