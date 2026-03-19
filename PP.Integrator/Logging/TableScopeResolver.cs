using Microsoft.Extensions.Logging;
using static PP.Integrator.Logging.LogTableScopesProvider;

internal static class TableScopeResolver
{
	private const string DefaultSchema = "logs";
	private const string DefaultTable = "log";
	private static readonly string[] Columns = { "timestamp", "loglevel", "category", "message", "eventid", "exception", "originalformat", "state" };

	public static string ResolveQualifiedTableName(IExternalScopeProvider scopeProvider)
	{
		var segments = new List<string>(4);
		scopeProvider.ForEachScope((scope, list) =>
		{
			var segment = scope switch
			{
				TableScope logScope => logScope.QualifiedTableName,
				string tableName => tableName,
				null => null,
				_ => scope.ToString()
			};

			if (string.IsNullOrWhiteSpace(segment))
				segment = DefaultTable;

			list.Add(segment);
		}, segments);

		return segments.Count == 0
			? $"{DefaultSchema}.{DefaultTable}"
			: $"{DefaultSchema}.{string.Join('_', segments)}";
	}

	public static string BuildCopyCommand(string qualifiedTableName) =>
		$"COPY  {qualifiedTableName} ({string.Join(',', Columns)}) FROM STDIN (FORMAT BINARY)";
}

