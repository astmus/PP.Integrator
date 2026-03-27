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
			static void Iterate(TableScope? current, Action<object?, TState> callback, TState state)
			{
				if (current == null)
					return;

				Iterate(current.Parent, callback, state);
				callback(current.State, state);
			}

			Iterate(_currentScope.Value, callback, state);
		}

		public IDisposable Push(object? state)
		{
			var createdScope = new TableScope(this, _currentScope.Value, state);
			_currentScope.Value = createdScope;
			return createdScope;
		}

		private static readonly string[] Columns =
		{
				"timestamp",
				"loglevel",
				"category",
				"message",
				"eventid",
				"exception",
				"originalformat",
				"state"
		};

		internal sealed class TableScope : IDisposable
		{
			private readonly LogTableScopesProvider _provider;
			private bool _disposed;

			internal static TableScope CreateDefault(LogTableScopesProvider provider) =>
				new(provider, null, null, true);

			internal TableScope(LogTableScopesProvider provider, TableScope? parent, object? state)
				: this(provider, parent, state, false)
			{
			}

			private TableScope(LogTableScopesProvider provider, TableScope? parent, object? state, bool isDefault)
			{
				_provider = provider;
				Parent = parent;
				State = state;
				Segments = BuildSegments(parent, state, isDefault);
				QualifiedTableName = CreateQualifiedTableName(Segments);
				CopyCommand = string.Intern($"COPY  {QualifiedTableName} ({string.Join(',', Columns)}) FROM STDIN (FORMAT BINARY)");
			}

			public TableScope? Parent { get; }

			public object? State { get; }

			public string[] Segments { get; }

			public string QualifiedTableName { get; }

			public string CopyCommand { get; }

			private static string[] BuildSegments(TableScope? parent, object? state, bool isDefault)
			{
				if (isDefault)
					return Array.Empty<string>();

				if (state is not string segment || string.IsNullOrWhiteSpace(segment))
					return parent?.Segments ?? new[] { DefaultLogTableName };

				if (parent == null || parent.Segments.Length == 0)
					return new[] { segment };

				var result = new string[parent.Segments.Length + 1];
				Array.Copy(parent.Segments, result, parent.Segments.Length);
				result[^1] = segment;
				return result;
			}

			private static string CreateQualifiedTableName(string[] segments) =>
				segments.Length == 0
					? $"{DefaultTable}.{DefaultLogTableName}"
					: $"{DefaultTable}.{string.Join('_', segments)}";

			public override string ToString() => QualifiedTableName;

			public void Dispose()
			{
				if (Volatile.Read(ref _disposed))
					return;

				Volatile.Write(ref _disposed, true);

				if (ReferenceEquals(_provider._currentScope.Value, this))
					_provider._currentScope.Value = Parent;
			}
		}
	}
}
