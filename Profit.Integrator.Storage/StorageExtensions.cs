using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Npgsql;
//using Profit.Integrator.Logging;

namespace Profit.Integrator.Storage
{
    public static class PostgreLoggerExtensions
    {
        //public static ILoggingBuilder AddPostgreLogger(this ILoggingBuilder builder)
        //{
        //    //builder.AddConfiguration();

        //    builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, PostgreLogProvider>());
        //    LoggerProviderOptions.RegisterProviderOptions<NpgsqlConnectionStringBuilder, PostgreLogProvider>(builder.Services);

        //    return builder;
        //}

        //public static ILoggingBuilder AddPostgreLogger(this ILoggingBuilder builder, Action<NpgsqlConnectionStringBuilder> configure)
        //{
        //    builder.AddPostgreLogger();
        //    builder.Services.Configure(configure);
        //    var cbulds = new Npgsql.NpgsqlConnectionStringBuilder();
        //    configure(cbulds);
        //    //builder.AddProvider(new PostgrePitLogProvider(cbulds));

        //    return builder;
        //}
    }
}


