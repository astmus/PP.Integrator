using System.Collections.Concurrent;

namespace PP.Integrator.Logging
{
	internal sealed class TablePartition : ConcurrentQueue<LogRecord>
	{
		public string QualifiedTableName { get; init; } = string.Empty;

		public string CopyCommand { get; init; } = string.Empty;
	}
}
