using System.Diagnostics;
#nullable disable
namespace PP
{
	/// <summary>
	/// Представляет собой дедлайн с фиксированным таймаутом и временем старта.
	/// Позволяет отслеживать прошедшее и оставшееся время, а также проверять истечение.
	/// </summary>
	public readonly struct Deadline
	{
		private readonly long _started;
		private readonly int _timeout;

		/// <summary>
		/// Представляет собой дефолтный дедлайн с фиксированным таймаутом в 100 мсек.
		/// </summary>
		public static readonly Deadline Default;

		Deadline(ushort timeout = 100)
		{
			_started = long.MinValue;
			_timeout = timeout;
		}

		///
		public override string ToString() => TimeSpan.FromMilliseconds(_timeout).ToString();

		/// <summary>
		/// Количество миллисекунд дедлайна.
		/// </summary>
		public int Timeout => _timeout;

		/// <summary>
		/// Неявное преобразование дедлайна в количество миллисекунд оставшихся до его истечения
		/// </summary>
		/// <param name="d">Экземпляр дедлайна.</param>
		public static implicit operator int(Deadline d) => d.Remaining;

		/// <summary>
		/// Создаёт новый дедлайн с указанным таймаутом в миллисекундах.
		/// </summary>
		/// <param name="timeoutMilliseconds">Таймаут в миллисекундах.</param>
		public Deadline(int timeoutMilliseconds)
		{
			_started = Stopwatch.GetTimestamp();
			_timeout = timeoutMilliseconds;
		}

		/// <summary>
		/// Создает новый дедлайн на основе имеющегося
		/// </summary>
		/// <param name="deadline">Экземпляр дедлайна.</param>
		public static Deadline BasedOn(Deadline deadline)
		{
			return new Deadline(deadline._timeout);		
		}

		/// <summary>
		/// Создает новый дедлайн на основе количества секунд
		/// </summary>
		/// <param name="seconds">Количество секундд.</param>
		public static Deadline FromSeconds(ushort seconds)
		{
			return new Deadline(seconds*1000);
		}

		/// <summary>
		/// Создаёт новый дедлайн на основе значения <see cref="TimeSpan"/>.
		/// </summary>
		/// <param name="timeout">Продолжительность таймаута.</param>
		public Deadline(TimeSpan timeout) : this((int)timeout.TotalMilliseconds)
		{
		}

		/// <summary>
		/// Количество миллисекунд, прошедших с момента создания дедлайна.
		/// </summary>
		public int Elapsed
		{
			get
			{
#if NET8_0_OR_GREATER
				return (int)Stopwatch.GetElapsedTime(_started).TotalMilliseconds;
#else
				var elapsedTicks = Stopwatch.GetTimestamp() - _started;
				return (int)(elapsedTicks * 1000L / Stopwatch.Frequency);
#endif
			}
		}

		/// <summary>
		/// Количество миллисекунд, оставшихся до истечения дедлайна.
		/// Возвращает 0, если время уже истекло.
		/// </summary>
		public int Remaining
			=> Math.Max(0, _timeout - Elapsed);

		/// <summary>
		/// Показывает, истёк ли дедлайн.
		/// </summary>
		public bool IsExpired
			=> Remaining == 0;

		/// <summary>
		/// Генерирует исключение <see cref="TimeoutException"/>,
		/// если дедлайн уже истёк.
		/// </summary>
		/// <param name="message">Сообщение исключения. Если не указано — используется сообщение по умолчанию.</param>
		/// <exception cref="TimeoutException">Выбрасывается, если дедлайн истёк.</exception>
		public void ThrowIfExpired(string message = null)
		{
			if (IsExpired)
				throw new TimeoutException(message ?? "Истекло время ожидания.");
		}
	}
}
#nullable restore
