#nullable disable
namespace PP
{
	/// <summary>
	/// Расширения для класса <see cref="Deadline"/>	
	/// </summary>
	public static class DeadlineExtensions
	{
		/// <summary>
		/// Создаёт новый дедлайн с линейным ростом таймаута
		/// относительно базового дедлайна:
		/// timeout = base.Timeout * step
		/// </summary>
		public static Deadline Linear(this Deadline deadline, int step, double growthFactor = 1, int maxTimeoutMilliseconds = int.MaxValue)
		{
			if (step < 0)
				throw new ArgumentOutOfRangeException(nameof(step));

			if (step == 0)
				step = 1;

			if (growthFactor < 0)
				throw new ArgumentOutOfRangeException(nameof(growthFactor));

			if (maxTimeoutMilliseconds < 0)
				throw new ArgumentOutOfRangeException(nameof(maxTimeoutMilliseconds));

			var timeout = deadline.Timeout * growthFactor * step;
			timeout = Math.Min(timeout, maxTimeoutMilliseconds);

			return new Deadline(ClampToInt(timeout));
		}

		/// <summary>
		/// Создаёт новый дедлайн с экспоненциальным ростом таймаута
		/// относительно базового дедлайна:
		/// timeout = base.Timeout * Exp(step)
		/// </summary>
		public static Deadline Exponential(this Deadline deadline, int step, int maxTimeoutMilliseconds = int.MaxValue)
		{
			if (step < 0)
				throw new ArgumentOutOfRangeException(nameof(step));

			if (maxTimeoutMilliseconds < 0)
				throw new ArgumentOutOfRangeException(nameof(maxTimeoutMilliseconds));

			double timeout = deadline.Timeout * Math.Exp(step);
			timeout = Math.Min(timeout, maxTimeoutMilliseconds);

			return new Deadline(ClampToInt(timeout));
		}

		/// <summary>
		/// Создаёт новый дедлайн с jitter.
		/// </summary>
		public static Deadline WithJitter(this Deadline deadline, int minJitterMilliseconds, int maxJitterMilliseconds)
		{
			if (minJitterMilliseconds < 0)
				throw new ArgumentOutOfRangeException(nameof(minJitterMilliseconds));

			if (maxJitterMilliseconds < minJitterMilliseconds)
				throw new ArgumentOutOfRangeException(nameof(maxJitterMilliseconds));

			int jitter = Random.Shared.Next(minJitterMilliseconds, maxJitterMilliseconds + 1);
			long timeout = (long)deadline.Timeout + jitter;

			return new Deadline(ClampToInt(timeout));
		}

		/// <summary>
		/// Создаёт новый дедлайн, у которого таймаут умножен на коэффициент.
		/// Удобно для произвольного масштабирования.
		/// </summary>
		public static Deadline Scale(this Deadline deadline, double factor, int maxTimeoutMilliseconds = int.MaxValue)
		{
			if (factor < 0)
				throw new ArgumentOutOfRangeException(nameof(factor));

			if (maxTimeoutMilliseconds < 0)
				throw new ArgumentOutOfRangeException(nameof(maxTimeoutMilliseconds));

			double timeout = deadline.Timeout * factor;
			timeout = Math.Min(timeout, maxTimeoutMilliseconds);

			return new Deadline(ClampToInt(timeout));
		}

		private static int ClampToInt(long value)
		{
			if (value <= 0)
				return 0;

			if (value >= int.MaxValue)
				return int.MaxValue;

			return (int)value;
		}

		private static int ClampToInt(double value)
		{
			if (value <= 0)
				return 0;

			if (value >= int.MaxValue)
				return int.MaxValue;

			return (int)value;
		}
	}

}
#nullable restore
