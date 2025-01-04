#nullable disable
namespace PP.Integrator.ChangeTracking
{

	public abstract record DataChangeContext
	{
		public DateTime Timestamp { get; set; }
		public ChangeKind Action { get; set; }
		public string DataBase { get; set; } = null!;
		public string Schema { get; set; } = null!;
		public string Table { get; set; } = null!;
	}
	
	public record ChangeItemInfo<Item> : DataChangeContext where Item : class
	{
		public Item New { get; set; }
		public Item Old { get; set; }
	}
}
#nullable restore