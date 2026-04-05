using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PP.Integrator.Logging;

namespace PP.Tests;

public class LoggingIntegrationTests
{
	[Fact]
	public void AddPostgreLogger_RegistersSingleProvider_AndFactoryCreatesLogger()
	{
		var services = new ServiceCollection();
		services.AddLogging(builder =>
		{
			var once = PP.Integrator.IntegratorLoggerExtensions.AddPostgreLogger(builder, static cfg => cfg.Host = "localhost");
			PP.Integrator.IntegratorLoggerExtensions.AddPostgreLogger(once, static cfg => cfg.Host = "localhost");
		});

		using var provider = services.BuildServiceProvider();
		var rootFactory = provider.GetRequiredService<IPostgreLoggerRootFactory>();
		Assert.NotNull(rootFactory);

		var logProviders = provider.GetServices<ILoggerProvider>().OfType<PostgreLogProvider>().ToArray();
		Assert.Single(logProviders);

		var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
		var logger = loggerFactory.CreateLogger("Integration.Category");
		Assert.NotNull(logger);
	}

	[Fact]
	public void AddPostgreLogger_DefaultsToUnifiedRootFactory()
	{
		var services = new ServiceCollection();
		services.AddLogging(builder =>
			PP.Integrator.IntegratorLoggerExtensions.AddPostgreLogger(builder, static cfg => cfg.Host = "localhost"));

		using var provider = services.BuildServiceProvider();
		var rootFactory = provider.GetRequiredService<IPostgreLoggerRootFactory>();
		Assert.IsType<PostgreLoggerRootFactory>(rootFactory);
	}

	[Fact]
	public void UseDataFlow_SetsUnifiedRootFactory()
	{
		var services = new ServiceCollection();
		services.AddLogging(builder =>
		{
			var withPostgre = PP.Integrator.IntegratorLoggerExtensions.AddPostgreLogger(builder, static cfg => cfg.Host = "localhost");
			PP.Integrator.IntegratorLoggerExtensions.UseDataFlow(withPostgre);
		});

		using var provider = services.BuildServiceProvider();
		var rootFactory = provider.GetRequiredService<IPostgreLoggerRootFactory>();
		Assert.IsType<PostgreLoggerRootFactory>(rootFactory);
	}

	[Fact]
	public void AddPostgreLogger_WithConfigure_RegistersLoggingDataSourceAccessor()
	{
		var services = new ServiceCollection();
		services.AddLogging(builder =>
			PP.Integrator.IntegratorLoggerExtensions.AddPostgreLogger(builder, cfg =>
			{
				cfg.Host = "db.local";
				cfg.Port = 5432;
				cfg.Database = "logs";
				cfg.Username = "tester";
			}));

		using var provider = services.BuildServiceProvider();
		var accessor = provider.GetRequiredService<IPostgreLoggingDataSourceAccessor>();
		Assert.NotNull(accessor);
		Assert.NotNull(accessor.DataSource);
	}
}
