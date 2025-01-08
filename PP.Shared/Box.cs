using System.Runtime.CompilerServices;
#nullable disable
namespace PP
{
	// пока оставлю их record'ами, возможно Deconstruct пригодится
	
	/// <summary>
	/// Базовый класс для избежания boxin \ unboxing и смешанных колекций из классов и типов значений
	/// </summary>
	public abstract record Box //: IStrongBox // если посмотреть нативную реализацию этого интерфейса то там тоже самое
	{
		/// <summary>
		/// Создать типизированный box по указателю
		/// </summary>
		/// <typeparam name="T">Тип внутреннего значения</typeparam>
		/// <param name="value">Внутреннее значение</param>
		/// <returns></returns>
		public static Box<T> Create<T>(ref T value)
			=> new Box<T>(value);

		/// <summary>
		/// Создать типизированный box
		/// </summary>
		/// <typeparam name="T">Тип внутреннего значения</typeparam>
		/// <param name="value">Внутреннее значение</param>
		/// <returns></returns>
		public static Box<T> Create<T>(T value)
			=> new Box<T>(value);

		/// <summary>
		/// Полчить внутреннее значение как тип <typeparamref name="T"/>
		/// </summary>
		/// <typeparam name="T">Тип внутреннего значения</typeparam>
		/// <returns></returns>
		public abstract T GetValue<T>();

		/// <summary>
		/// Полчить внутреннее значение как тип <typeparamref name="T"/>
		/// </summary>
		/// <typeparam name="T">Тип внутреннего значения</typeparam>
		/// <param name="value"></param>
		/// <returns>Возращает true если внутренее значение возможно привести к типу <typeparamref name="T"/> </returns>
		public abstract bool GetValue<T>(out T value);

		/// <summary>
		/// Распаковать значение как object если внутренний тип не известен
		/// </summary>
		public abstract object Unbox();
	}

	/// <summary>
	/// Класс для избежания boxin \ unboxing и смешанных колекций из классов и типов значений
	/// </summary>
	/// <typeparam name="T">Тип внутреннего значения</typeparam>
	public record Box<T> : Box
	{
		private T inner;
		
		/// Содержимое box		
		public T Content { get => inner; set => inner = value; }
		
		/// 	
		public Box(T val) 
			=> inner = val;

		/// <inheritdoc/>		
		public override TValue GetValue<TValue>()
			=> inner is TValue res ? res : default;

		/// <inheritdoc/>		
		public override bool GetValue<TV>(out TV value)
		{
			value = inner is TV res ? res : default;
			return value != null;
		}
		
		/// <inheritdoc/>		
		public override object Unbox()
			=> inner;

		/// <summary>
		/// Неявное приведение к Box`T.
		/// </summary>		
		public static implicit operator Box<T>(T value)
			=> Box.Create(ref value);
	}	
}
#nullable restore