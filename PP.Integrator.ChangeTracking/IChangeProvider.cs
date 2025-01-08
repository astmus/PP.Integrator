namespace PP.Integrator.ChangeTracking
{
	/// <summary>
	/// Интерфейс для класса профайдера изменений
	/// </summary>
	public interface IChangeProvider
	{
		/// <summary>
		/// Передает информацию об изменениях всем наблюдателям
		/// </summary>
		/// <param name="changes"></param>
		void Provide(string changes);
	}
}
