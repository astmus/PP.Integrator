using PP.Integrator.ChangeTracking;

namespace Examples
{
	internal class EventTriggerExample : ChangeConsumer<EventTrigger>
	{
		List<EventTrigger> triggers = new List<EventTrigger>();

		public override void OnCompleted() => throw new NotImplementedException();
		public override void OnError(Exception error) => throw new NotImplementedException();
		public override void OnCreate(EventTrigger item)
		{
			triggers.Add(item);
			Console.WriteLine("Itrem added "+item+ "total triggers "+ triggers.Count);
		}
		public override void OnDelete(EventTrigger deleted)
		{
			triggers.Remove(deleted);
			Console.WriteLine("Item deleted " + deleted + "total triggers " + triggers.Count);
		}
		public override void OnUpdate(EventTrigger current, EventTrigger old)
		{
			var item = triggers.Find(item => item == old);
			if (item == null)
			{
				Console.WriteLine("Item for update not found");
				return;
			}
			Console.WriteLine("Item updated was:" + item);
			var raw = Newtonsoft.Json.JsonConvert.SerializeObject(current);
			Newtonsoft.Json.JsonConvert.PopulateObject(raw, item);
			Console.WriteLine("Item updated become:" + item);
		}
	}

	public record EventTrigger
	{		
		public int Id { get; set; }
		public string Description { get; set; } = null!;
		public bool IsEnabled { get; set; } = true;
		public DateOnly? StartAt { get; set; }
		public virtual TimeOnly? RunAt { get; set; }
		public virtual TimeOnly? EndAt { get; set; }
		public virtual TimeSpan? Delay { get; set; }
		public TimeSpan? Interval { get; set; }
	}
}
