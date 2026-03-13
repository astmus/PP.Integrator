using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
	/// <inheritdoc/>
	public class LogTableScopesProvider : IExternalScopeProvider
	{
		private const string DefaultTable = "logs";
		private const string DefaultLogTableName = "log";
		private TableScope? _currentScope;

		/// <summary>
		/// Текущая целевая таблица
		/// </summary>
		public object? CurrentScope => _currentScope;
		///
		public LogTableScopesProvider(bool withDefaultScope = false)
		{
			if (withDefaultScope)
				_currentScope = TableScope.CreateDefault(this);
		}

		/// <inheritdoc/>
		public void ForEachScope<TState>(Action<object?, TState> callback, TState state)
		{
			if (_currentScope == null)
				return;

			callback(_currentScope.CopyCommand, state);
		}

		/// <inheritdoc/>
		public IDisposable Push(object? state)
		{
			var createdScope = new TableScope(this, _currentScope, state);
			_currentScope = createdScope;
			return createdScope;
		}

		internal class TableScope : IDisposable
		{
			private readonly LogTableScopesProvider _provider;
			private bool _disposed;

			internal static TableScope CreateDefault(LogTableScopesProvider provider) => new(provider, null, null, true);

			internal TableScope(LogTableScopesProvider provider, TableScope? parent, object? tableName)
				: this(provider, parent, tableName, false)
			{
			}

			private TableScope(LogTableScopesProvider provider, TableScope? parent, object? tableName, bool isDefault)
			{
				_provider = provider;
				Parent = parent;
				Segments = BuildSegments(parent, tableName, isDefault);
				QualifiedTableName = CreateQualifiedTableName(Segments);
				CopyCommand = $"COPY  {QualifiedTableName} ({string.Join(',', Columns())}) FROM STDIN (FORMAT BINARY)";
			}

			public TableScope? Parent { get; }

			public string[] Segments { get; }

			public string QualifiedTableName { get; }

			public string CopyCommand { get; }

			private static string[] BuildSegments(TableScope? parent, object? tableName, bool isDefault)
			{
				if (isDefault)
					return Array.Empty<string>();

				var normalized = NormalizeSegment(tableName);
				if (parent == null || parent.Segments.Length == 0)
					return new[] { normalized };

				var result = new string[parent.Segments.Length + 1];
				Array.Copy(parent.Segments, result, parent.Segments.Length);
				result[^1] = normalized;
				return result;
			}

			private static string CreateQualifiedTableName(string[] segments) =>
				segments.Length == 0
					? $"{DefaultTable}.{DefaultLogTableName}"
					: $"{DefaultTable}.{string.Join('_', segments)}_log";

			private static string NormalizeSegment(object? tableName)
			{
				var raw = tableName?.ToString();
				if (string.IsNullOrWhiteSpace(raw))
					return DefaultLogTableName;

				var chars = raw.Trim().ToLowerInvariant();
				var normalized = new char[chars.Length];
				for (var i = 0; i < chars.Length; i++)
				{
					var ch = chars[i];
					normalized[i] = ch is >= 'a' and <= 'z' or >= '0' and <= '9' or '_' ? ch : '_';
				}

				var prepared = string.Join('_', new string(normalized).Split('_', StringSplitOptions.RemoveEmptyEntries));
				return string.IsNullOrWhiteSpace(prepared) ? DefaultLogTableName : prepared;
			}

			public override string ToString() => QualifiedTableName;

			/// <summary>
			/// Последовательность столбцов в целефой таблице
			/// </summary>
			/// <returns></returns>
			public static IEnumerable<string> Columns()
			{
				yield return "timestamp";
				yield return "loglevel";
				yield return "category";
				yield return "message";
				yield return "eventid";
				yield return "exception";
				yield return "originalformat";
				yield return "state";
			}

			public void Dispose()
			{
				if (_disposed)
					return;

				if (ReferenceEquals(_provider._currentScope, this))
					_provider._currentScope = Parent;

				_disposed = true;
			}
		}
	}
}


