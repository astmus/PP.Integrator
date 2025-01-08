#nullable disable
namespace PP.Integrator.ChangeTracking
{
	/// <summary>
	/// Тип изменений данных
	/// </summary>
	public enum ChangeKind : byte
	{ 
		/// <summary>
		/// 
		/// </summary>
		Update,

		/// <summary>
		/// 
		/// </summary>
		Insert,

		/// <summary>
		/// 
		/// </summary>
		Delete
	}
}
#nullable restore