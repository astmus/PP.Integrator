namespace PP.Integrator.Logging
{
	/// <summary>
	/// Управляет скоростью чтения в буфер на основе его текущего заполнения.
	/// Использует 4 ступени по 25% от размера пачки.
	/// Задержка рассчитывается автоматически от BatchSize.
	/// </summary>
	internal sealed class BufferBackpressure
	{
		public int LowWatermark { get; }
		public int HighWatermark { get; }
		public int BufferSize { get; }
		public int BufferCount => bufferCount;

		int bufferCount;

		public BufferBackpressure(uint size)
		{
			BufferSize = Convert.ToInt32(size);
			LowWatermark = Convert.ToInt32(size * 0.3);
			HighWatermark = Convert.ToInt32(size * 0.6);
			bufferCount = 0;
		}

		public void Increment(int value = 1)
			=> Interlocked.Add(ref bufferCount, value);

		public void Decrement(int value = 1)
			=> Interlocked.Add(ref bufferCount, -value);

		/// <summary>
		/// Можно ли сейчас читать из источника в буфер.
		/// </summary>
		public bool ShouldRead()
		{
			return GetPressurePercents() < 80;
		}

		/// <summary>
		/// Возвращает задержку, автоматически рассчитанную от BatchSize.
		/// Формула:
		/// delayMs = bufferCount - BufferSize
		/// </summary>
		public int GetDelayMilliseconds()
		{
			var percents = GetPressurePercents();
			if (GetPressurePercents() < 50)
				return 0;

			int delayMs = Convert.ToInt32(percents);
			return Math.Max(0, delayMs);
		}

		/// <summary>
		/// Возвращает ValueTask, который:
		/// - сразу завершён, если задержка не нужна;
		/// - иначе ждёт автоматически рассчитанное время.
		/// </summary>
		public Task DelayAsync(CancellationToken cancellationToken = default)
		{
			int delayMs = GetDelayMilliseconds();

			if (delayMs <= 0)
				return Task.CompletedTask;

			return Task.Delay(delayMs, cancellationToken);
		}

		/// <summary>
		/// Возвращает давление в процентах.		
		/// </summary>
		public double GetPressurePercents()
		{
			return (double)bufferCount / BufferSize * 100.0;
		}
	}
}