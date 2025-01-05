using Microsoft.Extensions.Logging;

namespace PP.Integrator.Logging
{
    public record LogScope(string Table, LogLevel MinimumLevel = LogLevel.Information)
    {
    }
}


