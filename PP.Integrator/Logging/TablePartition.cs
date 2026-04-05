using System.Collections.Concurrent;
using Npgsql;

namespace PP.Integrator.Logging;

internal class TablePartition : ConcurrentQueue<LogRecord>
{
	public NpgsqlConnection? Connection { get; set; }
	public string TableName { get; } = string.Empty;
	public string CopyCommand { get; } = string.Empty;

	public TablePartition(string tableName, string copyCommand)
	{
		TableName = tableName;
		CopyCommand = copyCommand;
	}
}
