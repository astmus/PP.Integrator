using Microsoft.Extensions.Logging;
using Npgsql;
using PP.Integrator.Logging;

namespace PP.Tests;

public class LoggingContractsTests
{
	[Fact]
	public void IsEnabled_None_MustBeFalse()
	{
		var root = new SpyRootLogger(LogLevel.Trace);
		var logger = new PostgreDelegatedLogger("Test.Category", root);

		Assert.False(logger.IsEnabled(LogLevel.None));
	}

	[Fact]
	public void Log_WithoutBeginScope_MustStillWriteEntry_ToDefaultLogsScope()
	{
		var root = new SpyRootLogger(LogLevel.Trace);
		var logger = new PostgreDelegatedLogger("Test.Category", root);

		logger.Log(LogLevel.Information, new EventId(42, "evt"), "message", null, static (state, _) => state);

		var entry = Assert.Single(root.Entries);
		Assert.Equal("logs.log", entry.Scope?.ToString());
	}

	[Fact]
	public void BeginScope_Back_MustResolveToLogsDotBack()
	{
		var root = new SpyRootLogger(LogLevel.Trace);
		var logger = new PostgreDelegatedLogger("Test.Category", root);

		using (logger.BeginScope("back"))
		{
			logger.Log(LogLevel.Information, new EventId(1, "evt"), "msg", null, static (state, _) => state);
		}

		var entry = Assert.Single(root.Entries);
		Assert.Equal("logs.back_log", entry.Scope?.ToString());
	}

	[Fact]
	public void NestedScopes_MustUseUnderscoreAfterFirstScope()
	{
		var root = new SpyRootLogger(LogLevel.Trace);
		var logger = new PostgreDelegatedLogger("Test.Category", root);

		using (logger.BeginScope("back"))
		using (logger.BeginScope("archive"))
		{
			logger.Log(LogLevel.Information, new EventId(2, "evt"), "msg", null, static (state, _) => state);
		}

		var entry = Assert.Single(root.Entries);
		Assert.Equal("logs.back_archive_log", entry.Scope?.ToString());
	}

	[Fact]
	public void BeginScope_WithLogScope_MustNotLeakMinimumLevel_AfterDispose()
	{
		var root = new SpyRootLogger(LogLevel.Trace);
		var logger = new PostgreDelegatedLogger("Test.Category", root);

		Assert.True(logger.IsEnabled(LogLevel.Information));

		using (logger.BeginScope(new LogScope("logs", LogLevel.Error)))
		{
			Assert.False(logger.IsEnabled(LogLevel.Information));
		}

		Assert.True(logger.IsEnabled(LogLevel.Information));
	}

	[Fact]
	public void ExternalScopeProvider_ForEachScope_WithoutScope_MustNotThrow()
	{
		var provider = new LogTableScopesProvider();
		var collected = new List<object?>();

		var error = Record.Exception(() => provider.ForEachScope(static (scope, state) => state.Add(scope), collected));

		Assert.Null(error);
		Assert.Empty(collected);
	}

	[Fact]
	public void ExternalScopeProvider_ForEachScope_MustReturnRolledCopyCommand()
	{
		var provider = new LogTableScopesProvider();
		var collected = new List<string>();

		using (provider.Push("back"))
		{
			provider.ForEachScope(static (scope, state) => state.Add(scope?.ToString() ?? string.Empty), collected);
		}

		var command = Assert.Single(collected);
		Assert.StartsWith("COPY  logs.back_log (", command, StringComparison.Ordinal);
		Assert.EndsWith("FROM STDIN (FORMAT BINARY)", command, StringComparison.Ordinal);
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

		var command = Assert.Single(collected);
		Assert.Contains("logs.outer_table_log", command?.ToString(), StringComparison.Ordinal);
	}

	[Fact]
	public void ScopeToString_MustReturnOnlyScopeName()
	{
		var provider = new LogTableScopesProvider();
		using (provider.Push("back"))
		using (provider.Push("archive"))
		{
			Assert.Equal("logs.back_archive_log", provider.CurrentScope?.ToString());
		}
	}

	private sealed class SpyRootLogger : PostgreLoggerBase
	{
		public SpyRootLogger(LogLevel defaultLogLevel)
			: base(
				"Spy.Context",
				NpgsqlDataSource.Create(new NpgsqlConnectionStringBuilder { Host = "localhost", Database = "test" }),
				new PostgreLoggerProviderOptions(),
				defaultLogLevel)
		{
		}

		public List<LogRecord> Entries { get; } = new();

		protected override void InitializeCore()
		{
		}

		protected override void EnqueueEntry(LogRecord entry)
		{
			Entries.Add(entry);
		}

		public override void Flush()
		{
		}
	}
}
