using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
	/// <summary>
	/// Options used by <see cref="PostgreLogProvider"/>.
	/// </summary>
	public sealed class PostgreLoggerProviderOptions
	{
		/// <summary>
		/// Maximum buffered items before immediate flush.
		/// </summary>
		public int MaxBufferItemsCount { get; set; } = 4096;

		/// <summary>
		/// Auto flush timeout in milliseconds for partial batches.
		/// </summary>
		public int AutoFlushDuration { get; set; } = 8192;

		/// <summary>
		/// Number of retries for transient write errors.
		/// </summary>
		public int WriteRetryCount { get; set; } = 3;

		/// <summary>
		/// Optional override for default minimum log level.
		/// If null, level is read from global logging settings.
		/// </summary>
		public LogLevel? DefaultLogLevel { get; set; }
	}
}
