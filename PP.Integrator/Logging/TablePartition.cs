using System.Collections.Concurrent;
using Npgsql;

namespace PP.Integrator.Logging;

internal class TablePartition : ConcurrentQueue<LogRecord>
{
	public string TableName { get; } = string.Empty;
	public string CopyCommand { get; } = string.Empty;

	public TablePartition(string tableName, string copyCommand)
	{
		TableName = tableName;
		CopyCommand = copyCommand;
	}

	private int _isProcessing;
	public bool IsProcessing => Volatile.Read(ref _isProcessing) == 1;

	public TablePartition NewPartition
		=> new TablePartition(TableName, CopyCommand);

	public bool TryBeginProcessing()
	{
		return Interlocked.CompareExchange(ref _isProcessing, 1, 0) == 0;
	}

	public void EndProcessing()
	{
		Volatile.Write(ref _isProcessing, 0);
	}
}
