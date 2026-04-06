using Npgsql;
using PP.Shared.Extensions;

namespace PP.Integrator.Logging;
/// <summary>
/// Создаёт и владеет <see cref="NpgsqlDataSource" /> для Postgre-логгера.
/// </summary>
internal sealed class PostgreLoggingDataSourceAccessor : IPostgreLoggingDataSourceAccessor, IDisposable
{
	private readonly Lazy<NpgsqlDataSource> _lazyDataSource;
	private int _disposed;

	/// <summary>
	/// Инициализирует accessor фабрикой создания <see cref="NpgsqlDataSource" />.
	/// </summary>
	/// <param name="factory">Фабрика создания data source.</param>
	public PostgreLoggingDataSourceAccessor(Func<NpgsqlDataSource> factory)
	{
		GuardEx.ThrowIfNull(factory, nameof(factory));
		_lazyDataSource = new Lazy<NpgsqlDataSource>(factory, LazyThreadSafetyMode.ExecutionAndPublication);
	}

	/// <summary>
	/// Возвращает экземпляр <see cref="NpgsqlDataSource" /> для логгера.
	/// </summary>
	public NpgsqlDataSource DataSource
	{
		get
		{
			GuardEx.ThrowIfDisposed(Volatile.Read(ref _disposed) == 1, this);
			return _lazyDataSource.Value;
		}
	}

	/// <summary>
	/// Освобождает созданный <see cref="NpgsqlDataSource" />, если он был инициализирован.
	/// </summary>
	public void Dispose()
	{
		if (Interlocked.Exchange(ref _disposed, 1) == 1)
			return;

		if (_lazyDataSource.IsValueCreated)
			_lazyDataSource.Value.Dispose();
	}
}
