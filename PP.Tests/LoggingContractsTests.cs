using Microsoft.Extensions.Logging;
using Npgsql;
using PP.Integrator.Logging;

namespace PP.Tests;

public class LoggingContractsTests
{
	[Fact]
	public void IsEnabled_None_MustBeFalse()
	{
		var root = new SpyRootLogger();
		var logger = new PostgreDelegatedLogger("Test.Category", root);

		Assert.False(logger.IsEnabled(LogLevel.None));
	}

	[Fact]
	public void Log_WithoutBeginScope_MustStillWriteEntry_ToDefaultLogsScope()
	{
		var root = new SpyRootLogger();
		var logger = new PostgreDelegatedLogger("Test.Category", root);

		logger.Log(LogLevel.Information, new EventId(42, "evt"), "message", null, static (state, _) => state);

		var entry = Assert.Single(root.Entries);
		Assert.Equal("logs.log", entry.Scope?.ToString());
	}

	[Fact]
	public void BeginScope_Back_MustResolveToLogsDotBack()
	{
		var root = new SpyRootLogger();
		var logger = new PostgreDelegatedLogger("Test.Category", root);

		using (logger.BeginScope("back"))
		{
			logger.Log(LogLevel.Information, new EventId(1, "evt"), "msg", null, static (state, _) => state);
		}

		var entry = Assert.Single(root.Entries);
		Assert.Equal("logs.back", entry.Scope?.ToString());
	}

	[Fact]
	public void NestedScopes_MustUseUnderscoreAfterFirstScope()
	{
		var root = new SpyRootLogger();
		var logger = new PostgreDelegatedLogger("Test.Category", root);

		using (logger.BeginScope("back"))
		using (logger.BeginScope("archive"))
		{
			logger.Log(LogLevel.Information, new EventId(2, "evt"), "msg", null, static (state, _) => state);
		}

		var entry = Assert.Single(root.Entries);
		Assert.Equal("logs.back_archive", entry.Scope?.ToString());
	}

	[Fact]
	public void BeginScope_WithObjectState_MustUseScopeToString()
	{
		var root = new SpyRootLogger();
		var logger = new PostgreDelegatedLogger("Test.Category", root);
		using var _ = logger.BeginScope(new ScopeState("special_scope"));
		logger.Log(LogLevel.Information, new EventId(3, "evt"), "msg", null, static (state, _) => state);

		var entry = Assert.Single(root.Entries);
		Assert.Equal("logs.log", entry.Scope?.ToString());
	}

	[Fact]
	public void IsEnabled_Information_MustBeTrue()
	{
		var root = new SpyRootLogger();
		var logger = new PostgreDelegatedLogger("Test.Category", root);

		Assert.True(logger.IsEnabled(LogLevel.Information));
	}

	[Fact]
	public void ExternalScopeProvider_ForEachScope_DefaultScope_MustReturnSingleNull()
	{
		var provider = new LogTableScopesProvider();
		var collected = new List<object?>();

		var error = Record.Exception(() => provider.ForEachScope(static (scope, state) => state.Add(scope), collected));

		Assert.Null(error);
		Assert.Single(collected);
		Assert.Null(collected[0]);
	}

	[Fact]
	public void ExternalScopeProvider_ForEachScope_WithStringScope_MustReturnDefaultAndScope()
	{
		var provider = new LogTableScopesProvider();
		var collected = new List<string>();

		using (provider.Push("back"))
		{
			provider.ForEachScope(static (scope, state) => state.Add(scope?.ToString() ?? string.Empty), collected);
		}

		Assert.Equal(2, collected.Count);
		Assert.Equal(string.Empty, collected[0]);
		Assert.Equal("back", collected[1]);
	}

	[Fact]
	public void ExternalScopeProvider_MustSupportNestedScopes_Lifo()
	{
		var provider = new LogTableScopesProvider();
		var collected = new List<object?>();

		using var outer = provider.Push("outer_table");
		using (provider.Push("inner_table"))
		{
			provider.ForEachScope(static (scope, state) => state.Add(scope), collected);
		}

		collected.Clear();
		provider.ForEachScope(static (scope, state) => state.Add(scope), collected);

		Assert.Equal(2, collected.Count);
		Assert.Null(collected[0]);
		Assert.Equal("outer_table", collected[1]);
	}

	[Fact]
	public void ScopeToString_MustReturnOnlyScopeName()
	{
		var provider = new LogTableScopesProvider();
		using (provider.Push("back"))
		using (provider.Push("archive"))
			Assert.Equal("logs.back_archive", provider.CurrentScope?.ToString());
	}

	private sealed class SpyRootLogger : PostgreLogger
	{
		public SpyRootLogger()
			: base(new TestDataSourceAccessor(), new PostgreLoggerProviderOptions())
		{
		}

		public List<LogRecord> Entries { get; } = new();

		protected override void Initialize()
		{
		}

		protected override void EnqueueEntry(LogRecord entry)
		{
			Entries.Add(entry);
		}

	}

	private sealed record ScopeState(string Name)
	{
		public override string ToString() => Name;
	}

	private sealed class TestDataSourceAccessor : IPostgreLoggingDataSourceAccessor
	{
		public NpgsqlDataSource DataSource { get; } =
			NpgsqlDataSource.Create(new NpgsqlConnectionStringBuilder { Host = "localhost", Database = "test" }.ConnectionString);
	}
}
