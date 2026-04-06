using Npgsql;

namespace PP.Integrator.Logging;
/// <summary>
/// Предоставляет <see cref="NpgsqlDataSource" /> исключительно для инфраструктуры Postgre-логирования.
/// </summary>
internal interface IPostgreLoggingDataSourceAccessor
{
	/// <summary>
	/// Возвращает экземпляр <see cref="NpgsqlDataSource" /> для логгера.
	/// </summary>
	NpgsqlDataSource DataSource { get; }
}


