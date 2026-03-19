using System.Collections.Concurrent;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
	internal class LogTableScopesProvider : IExternalScopeProvider
	{
		private const string DefaultTable = "logs";
		private const string DefaultLogTableName = "log";
		private readonly AsyncLocal<TableScope?> _currentScope = new();

		internal TableScope? CurrentScope => _currentScope.Value;

		public LogTableScopesProvider(bool withDefaultScope = true)
		{
			if (withDefaultScope)
				_currentScope.Value = TableScope.CreateDefault(this);
		}

		public void ForEachScope<TState>(Action<object?, TState> callback, TState state)
		{
			void Iterate(TableScope? current)
			{
				if (current == null)
					return;

				Iterate(current.Parent);
				callback(current.State, state);
			}
			Iterate(_currentScope.Value);
		}

		public IDisposable Push(object? state)
		{
			var createdScope = new TableScope(this, _currentScope.Value, state);
			_currentScope.Value = createdScope;
			return createdScope;
		}

		internal class TableScope : IDisposable
		{
			private static readonly string[] Columns = { "timestamp", "loglevel", "category", "message", "eventid", "exception", "originalformat", "state" };

			private readonly LogTableScopesProvider _provider;

			internal static TableScope CreateDefault(LogTableScopesProvider provider) => new(provider, null, null, true);

			internal TableScope(LogTableScopesProvider provider, TableScope? parent, object? tableName)
				: this(provider, parent, tableName, false)
			{
			}

			private TableScope(LogTableScopesProvider provider, TableScope? parent, object? tableName, bool isDefault)// : base(maxBufferSize)			
			{
				_provider = provider;
				Parent = parent;
				State = tableName;
				Segments = BuildSegments(parent, tableName, isDefault);
				QualifiedTableName = CreateQualifiedTableName(Segments);
				CopyCommand = string.Intern($"COPY  {QualifiedTableName} ({string.Join(',', Columns)}) FROM STDIN (FORMAT BINARY)");
			}

			public TableScope? Parent { get; }

			public object? State { get; }

			public string[] Segments { get; }

			public string QualifiedTableName { get; }

			public string CopyCommand { get; }

			private static string[] BuildSegments(TableScope? parent, object? tableName, bool isDefault)
			{
				if (isDefault)
					return Array.Empty<string>();

				var normalized = tableName?.ToString();
				if (string.IsNullOrWhiteSpace(normalized))
					normalized = DefaultLogTableName;
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
					: $"{DefaultTable}.{string.Join('_', segments)}";

			public override string ToString() => QualifiedTableName;

			bool disposed;
			public void Dispose()
			{
				if (Volatile.Read(ref disposed)) return;
				Volatile.Write(ref disposed, true);

				if (ReferenceEquals(_provider._currentScope.Value, this))
					_provider._currentScope.Value = Parent;
			}
		}
	}
}
