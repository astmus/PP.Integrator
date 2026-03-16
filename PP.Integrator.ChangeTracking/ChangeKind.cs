#nullable disable
namespace PP.Integrator.ChangeTracking
{
	/// <summary>
	/// Тип изменений данных
	/// </summary>
	public enum ChangeKind : byte
	{ 
		/// <summary>
		/// Изменение существующей записи.
		/// </summary>
		Update,

		/// <summary>
		/// Добавление новой записи.
		/// </summary>
		Insert,

		/// <summary>
		/// Удаление записи.
		/// </summary>
		Delete
	}
}
#nullable restore
