#nullable disable
namespace PP.Integrator.ChangeTracking
{
	/// <summary>
	/// Содержит информацию о контексте в котором произошли изменения
	/// </summary>
	public abstract record DataChangeContext
	{
		/// <summary>
		/// Время изменения
		/// </summary>
		public DateTime Timestamp { get; set; }

		/// <summary>
		/// Тип изменения
		/// </summary>
		public ChangeKind Action { get; set; }

		/// <summary>
		/// Название базы
		/// </summary>
		public string DataBase { get; set; } = null!;

		/// <summary>
		/// Название схемы
		/// </summary>
		public string Schema { get; set; } = null!;

		/// <summary>
		/// Название таблицы
		/// </summary>
		public string Table { get; set; } = null!;
	}
	
	/// <summary>
	/// Содержит данные которые изменились
	/// </summary>
	/// <typeparam name="Item"></typeparam>
	public record ChangeItemInfo<Item> : DataChangeContext where Item : class
	{
		/// <summary>
		/// Обновленные значения данных
		/// </summary>
		public Item New { get; set; }

		/// <summary>
		/// Предидущие значения данных
		/// </summary>
		public Item Old { get; set; }
	}
}
#nullable restore