using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
    /// <summary>
    /// Класс конфигурации скоупа логирования
    /// </summary>
    /// <param name="Table">Название таблицы логирования</param>
    /// <param name="MinimumLevel">Минимальный уровень логирования</param>
    public record LogScope(string Table, LogLevel MinimumLevel = LogLevel.Information)
    {
    }
}


