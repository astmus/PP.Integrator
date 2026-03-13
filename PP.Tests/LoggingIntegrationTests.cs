using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;
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
	public void AddPostgreLogger_DefaultsToClassicRootFactory()
	{
		var services = new ServiceCollection();
		services.AddLogging(builder =>
			PP.Integrator.IntegratorLoggerExtensions.AddPostgreLogger(builder, static cfg => cfg.Host = "localhost"));

		using var provider = services.BuildServiceProvider();
		var rootFactory = provider.GetRequiredService<IPostgreLoggerRootFactory>();
		Assert.IsType<PostgreClassicLoggerRootFactory>(rootFactory);
	}

	[Fact]
	public void UseAutoWait_ReplacesRootFactory()
	{
		var services = new ServiceCollection();
		services.AddLogging(builder =>
		{
			var withPostgre = PP.Integrator.IntegratorLoggerExtensions.AddPostgreLogger(builder, static cfg => cfg.Host = "localhost");
			PP.Integrator.IntegratorLoggerExtensions.UseAutoWait(withPostgre);
		});

		using var provider = services.BuildServiceProvider();
		var rootFactory = provider.GetRequiredService<IPostgreLoggerRootFactory>();
		Assert.IsType<PostgreAutoWaitLoggerRootFactory>(rootFactory);
	}

	[Fact]
	public void UseClassic_AfterUseAutoWait_SetsClassicRootFactory()
	{
		var services = new ServiceCollection();
		services.AddLogging(builder =>
		{
			var withPostgre = PP.Integrator.IntegratorLoggerExtensions.AddPostgreLogger(builder, static cfg => cfg.Host = "localhost");
			var withAutoWait = PP.Integrator.IntegratorLoggerExtensions.UseAutoWait(withPostgre);
			PP.Integrator.IntegratorLoggerExtensions.UseClassic(withAutoWait);
		});

		using var provider = services.BuildServiceProvider();
		var rootFactory = provider.GetRequiredService<IPostgreLoggerRootFactory>();
		Assert.IsType<PostgreClassicLoggerRootFactory>(rootFactory);
	}

	[Fact]
	public void AddPostgreLogger_WithConfigure_RegistersNpgsqlDataSourceInContainer()
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
		var dataSource = provider.GetRequiredService<NpgsqlDataSource>();
		Assert.NotNull(dataSource);
	}
}
