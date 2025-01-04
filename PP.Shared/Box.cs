using System.Runtime.CompilerServices;
#nullable disable
namespace PP
{
	// пока оставлю их record'ами, возможно Deconstruct пригодится
	public abstract record Box : IStrongBox // если посмотреть нативную реализацию этого интерфейса то там тоже самое
	{
		public object Value { get; set; }

		public static Box<T> Create<T>(ref T value)
			=> new Box<T>(value);
		public static Box<T> Create<T>(T value)
			=> new Box<T>(value);
	
		public abstract T GetValue<T>();
		public abstract bool GetValue<T>(out T value);
		public abstract object Unbox();
	}

	public record Box<T> : Box
	{
		private T value;
		public Box(T val) => value = val;
		public T Content { get => value; set => this.value = value; }

		public override TValue GetValue<TValue>()
			=> value is TValue res ? res : default;

		public override object Unbox()
			=> value;

		public static implicit operator Box<T>(T value)
			=> Box.Create(ref value);

		public override bool GetValue<TV>(out TV value)
		{
			value = GetValue<TV>();
			return value != null;
		}
	}	
}
#nullable restore