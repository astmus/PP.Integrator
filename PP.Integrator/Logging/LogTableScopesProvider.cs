using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
	public class LogTableScopesProvider : IExternalScopeProvider
	{
		public object CurrentScope { get; set; }

		public void ForEachScope<TState>(Action<object?, TState> callback, TState state)
		{
			void Rollup(TableScope scope)
			{
				if (scope == null)
					ArgumentNullException.ThrowIfNull(scope);
			
				var start = $"COPY  {scope.State} (";
				var columns = string.Join(',', scope.Columns());
				var end = ") FROM STDIN (FORMAT BINARY)";
				callback($"{start}{columns}{end}", state);
			}
			Rollup((TableScope)CurrentScope);
		}

		public IDisposable Push(object? state)
		{
			(CurrentScope as TableScope)?.Dispose();
			return (TableScope)(CurrentScope = new TableScope(this, state));
		}

		internal class TableScope : IDisposable
		{
			private LogTableScopesProvider _provider;
			internal TableScope(LogTableScopesProvider provider, object? tableName)
			{
				_provider = provider;
				State = tableName;
			}

			public object? State { get; }
			string _context;
			public override string? ToString()
			{
				// попробовать заменить на интернирование
				return _context ?? (_context = $"COPY  {State} ({string.Join(',', Columns())}) FROM STDIN (FORMAT BINARY)");
			}

			public virtual IEnumerable<string> Columns()
			{
				yield return "timestamp";
				yield return "loglevel";
				yield return "category";
				yield return "eventid  ";
				yield return "originalformat";
				yield return "message";
				yield return "exception";
				yield return "state";
			}

			private bool disposedValue;

			protected virtual void Dispose(bool disposing)
			{				
			}
			
			public void Dispose()
			{
				if (!disposedValue)
				{					
					_provider.CurrentScope = null;
					_provider = null;
					disposedValue = true;
				}
			}
		}
	}
}


