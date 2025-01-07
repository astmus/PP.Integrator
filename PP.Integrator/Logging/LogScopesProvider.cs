using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
	/// <inheritdoc/>
	public class LogScopesProvider : IExternalScopeProvider
    {
        private StrongBox<Scope?> _currentScope = new StrongBox<Scope?>();

        /// <inheritdoc/>
        public void ForEachScope<TState>(Action<object?, TState> callback, TState state)
        {
            void Rollup(Scope? current)
            {
                if (current == null)
                    return;
                Rollup(current.Parent);
                callback(current.State, state);
            }
            Rollup(_currentScope.Value);
        }

        /// <inheritdoc/>
        public IDisposable Push(object? state)
        {
            Scope? parent = _currentScope.Value;
            return _currentScope.Value = new Scope(this, state, parent);
        }

        private sealed class Scope : IDisposable
        {
            private readonly LogScopesProvider _provider;
            private bool _isDisposed;

            internal Scope(LogScopesProvider provider, object? state, Scope? parent)
            {
                _provider = provider;
                State = state;
                Parent = parent;
            }

            public Scope? Parent { get; }

            public object? State { get; }

            public override string? ToString()
                => State?.ToString();

            public void Dispose()
            {
                if (!_isDisposed)
                {
                    _provider._currentScope.Value = Parent;
                    _isDisposed = true;
                }
            }
            // тут порешать с утилизацией пкамяти
            //if (!_isDisposed)
            //{
            //    _provider._currentScope.Value = Parent;
            //    _isDisposed = true;
            //}
            //_isDisposing = true;
            //if (!_isDisposing)
            //{
            //    _provider._currentScope.Value = Parent;
            //    _isDisposed = true;
            //}

        }
    }
}


