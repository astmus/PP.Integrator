using System.Diagnostics;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Logging;
using Npgsql;
using PP.Integrator;

namespace BenchCounters;

public static class LoggerBenchmarkRunner
{
	private const string BenchmarkScopeName = "logs_benchmark";
	private const string BenchmarkSchemaName = "logs";
	private const string BenchmarkTableName = "logs_benchmark_log";
	private const string BenchmarkQualifiedTableName = $"{BenchmarkSchemaName}.{BenchmarkTableName}";
	private static readonly TimeSpan BenchmarkWindow = TimeSpan.FromMinutes(1);
	private static readonly TimeSpan CountersWindow = TimeSpan.FromMinutes(1) + TimeSpan.FromSeconds(5);
	private static bool _environmentPrinted;

	private static string FormatBytes(long bytes)
	{
		var value = Math.Abs((double)bytes);
		var units = new[] { "B", "KB", "MB", "GB", "TB" };
		var unit = 0;
		while (value >= 1024 && unit < units.Length - 1)
		{
			value /= 1024;
			unit++;
		}

		return $"{value:N2} {units[unit]}";
	}

	private static string FormatNullableBytes(long bytes) => bytes < 0 ? "n/a" : FormatBytes(bytes);

	private static string FormatNullableLong(long value) => value < 0 ? "n/a" : value.ToString("N0");

	private static double GetMeanUsPerOp(ScenarioResult result) => result.Messages > 0 ? (result.DurationMs * 1000.0) / result.Messages : 0;

	private static void PrintBenchmarkEnvironmentIfNeeded()
	{
		if (_environmentPrinted)
			return;

		_environmentPrinted = true;
		Console.WriteLine("=== Benchmark Environment ===");
		Console.WriteLine($"Runtime: .NET {Environment.Version}");
		Console.WriteLine($"OS: {RuntimeInformation.OSDescription}");
		Console.WriteLine($"Arch: {RuntimeInformation.OSArchitecture} / Process {RuntimeInformation.ProcessArchitecture}");
		Console.WriteLine($"CPU logical processors: {Environment.ProcessorCount}");
		Console.WriteLine($"GC mode: {(System.Runtime.GCSettings.IsServerGC ? "Server" : "Workstation")}");
		Console.WriteLine("=============================");
	}

	private static void PrintComparison(ScenarioResult classic, ScenarioResult autoWait)
	{
		Console.WriteLine();
		Console.WriteLine("=== Benchmark Summary ===");
		Console.WriteLine($"Runtime=.NET {Environment.Version}, OS={RuntimeInformation.OSDescription}, CPU logical={Environment.ProcessorCount}, GC={(System.Runtime.GCSettings.IsServerGC ? "Server" : "Workstation")}");
		Console.WriteLine("| Method           | Mean (us/op) | Ops/s     | Messages  | RowsInDb  | DbDelta   |");
		Console.WriteLine("|------------------|-------------:|----------:|----------:|----------:|----------:|");
		Console.WriteLine($"| {classic.Title,-16} | {GetMeanUsPerOp(classic),11:N2} | {classic.LogsPerSecond,9:N0} | {classic.Messages,9:N0} | {FormatNullableLong(classic.RowsWritten),9} | {FormatNullableBytes(classic.DbBytesDelta),9} |");
		Console.WriteLine($"| {autoWait.Title,-16} | {GetMeanUsPerOp(autoWait),11:N2} | {autoWait.LogsPerSecond,9:N0} | {autoWait.Messages,9:N0} | {FormatNullableLong(autoWait.RowsWritten),9} | {FormatNullableBytes(autoWait.DbBytesDelta),9} |");
		Console.WriteLine($"Speed ratio (AutoWait / ReadWhileWrite): {(autoWait.LogsPerSecond / Math.Max(classic.LogsPerSecond, 1e-9)):N2}x");
		if (classic.AvgBytesPerAttempted >= 0 && autoWait.AvgBytesPerAttempted >= 0)
			Console.WriteLine($"Avg bytes / attempted message: read-while-write={FormatBytes((long)classic.AvgBytesPerAttempted)}, autowait={FormatBytes((long)autoWait.AvgBytesPerAttempted)}");

		if (classic.AvgBytesPerInserted >= 0 && autoWait.AvgBytesPerInserted >= 0)
			Console.WriteLine($"Avg bytes / inserted row: read-while-write={FormatBytes((long)classic.AvgBytesPerInserted)}, autowait={FormatBytes((long)autoWait.AvgBytesPerInserted)}");
	}

	private static void PrintDbStats(string title, long rowsWritten, long dbBytes, double avgBytesPerAttempted, double avgBytesPerInserted)
	{
		if (rowsWritten < 0 || dbBytes < 0)
		{
			Console.WriteLine($"[{title}] DB metrics unavailable (could not read table stats).");
			return;
		}

		Console.WriteLine($"[{title}] DB rows inserted: {rowsWritten:N0}");
		Console.WriteLine($"[{title}] DB size delta: {FormatBytes(dbBytes)}");
		Console.WriteLine($"[{title}] Avg bytes / attempted message: {FormatBytes((long)Math.Max(0, avgBytesPerAttempted))}");
		if (rowsWritten > 0)
			Console.WriteLine($"[{title}] Avg bytes / inserted row: {FormatBytes((long)Math.Max(0, avgBytesPerInserted))}");
	}

	public static void RunAutoWait() =>
		RunScenarioWithCounters(builder => builder.UseAutoWait(), "autowait");

	public static void RunAutoWaitFocusedBenchmarkDotNet() =>
		BenchmarkRunner.Run<AutoWaitFocusedBenchmarkDotNet>();

	public static void RunAutoWaitDirect() => RunScenario(builder => builder.UseAutoWait(), "autowait");

	public static void RunBenchmarkDotNet() => BenchmarkRunner.Run<LoggerBenchmarkDotNet>();

	public static void RunComparison() => RunComparisonWithDotnetCounters();

	public static void RunReadWhileWrite() => RunScenarioWithCounters(builder => builder.UseClassic(), "read-while-write");

	public static void RunReadWhileWriteDirect() => RunScenario(builder => builder.UseClassic(), "read-while-write");

	private static ScenarioResult RunScenarioWithCounters(Action<ILoggingBuilder> useLoggerKind, string title)
	{
		StartCountersSidecar(title);
		return RunScenario(useLoggerKind, title);
	}

	private static ScenarioResult RunScenario(Action<ILoggingBuilder> useLoggerKind, string title)
	{
		PrintBenchmarkEnvironmentIfNeeded();
		var dbBefore = TryReadDbStats(BenchmarkQualifiedTableName);

		using var factory = LoggerFactory.Create(builder =>
		{
			builder.ClearProviders();
			builder.AddPostgreLogger(ExampleDbConnection.Configure);
			useLoggerKind(builder);
		});

		var logger = factory.CreateLogger($"benchmark-{title}");
		using var scope = logger.BeginScope(BenchmarkScopeName);
		var sw = Stopwatch.StartNew();
		long messages = 0;

		while (sw.Elapsed < BenchmarkWindow)
		{
			logger.LogInformation("Benchmark mode={Mode} index={Index}", title, messages);
			messages++;
		}

		sw.Stop();
		var logsPerSecond = messages / Math.Max(sw.Elapsed.TotalSeconds, 1e-9);
		Console.WriteLine($"[{title}] Wrote {messages} log entries in {sw.Elapsed.TotalMilliseconds:N0} ms (target window: {BenchmarkWindow.TotalSeconds:N0} s, throughput: {logsPerSecond:N0} logs/sec)");
		var dbAfter = TryReadDbStats(BenchmarkQualifiedTableName);

		var rowsWritten = (dbBefore != null && dbAfter != null) ? Math.Max(0, dbAfter.RowCount - dbBefore.RowCount) : -1;
		var dbBytes = (dbBefore != null && dbAfter != null) ? Math.Max(0, dbAfter.TotalRelationBytes - dbBefore.TotalRelationBytes) : -1;
		var avgBytesPerAttempted = dbBytes >= 0 && messages > 0 ? (double)dbBytes / messages : -1;
		var avgBytesPerInserted = dbBytes >= 0 && rowsWritten > 0 ? (double)dbBytes / rowsWritten : -1;

		PrintDbStats(title, rowsWritten, dbBytes, avgBytesPerAttempted, avgBytesPerInserted);
		return new ScenarioResult(title, messages, sw.Elapsed.TotalMilliseconds, logsPerSecond, rowsWritten, dbBytes, avgBytesPerAttempted, avgBytesPerInserted);
	}

	private static void RunComparisonWithDotnetCounters()
	{
		Console.WriteLine("Running one-minute comparison. dotnet-counters starts in separate window per scenario.");
		var readWhileWrite = RunScenarioWithCounters(builder => builder.UseClassic(), "read-while-write");
		var autoWait = RunScenarioWithCounters(builder => builder.UseAutoWait(), "autowait");
		PrintComparison(readWhileWrite, autoWait);
	}

	private static void StartCountersSidecar(string title)
	{
		try
		{
			var durationArg = ToDurationArg(CountersWindow);
			var pid = Environment.ProcessId;
			var countersArgs =
				$"monitor --process-id {pid} --counters System.Runtime --refresh-interval 1 --duration {durationArg} --showDeltas";
			var psi = new ProcessStartInfo
			{
				FileName = "powershell",
				UseShellExecute = false,
				CreateNoWindow = true,
				WorkingDirectory = AppContext.BaseDirectory
			};
			psi.ArgumentList.Add("-NoProfile");
			psi.ArgumentList.Add("-Command");
			psi.ArgumentList.Add($"Start-Process -FilePath 'dotnet-counters' -ArgumentList '{countersArgs}'");
			Process.Start(psi);
			Console.WriteLine($"[{title}] dotnet-counters opened in separate window (pid={pid}, duration={durationArg}).");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"[{title}] Failed to start counters sidecar: {ex.Message}");
		}
	}

	private static string ToDurationArg(TimeSpan duration)
	{
		var totalSeconds = (int)Math.Ceiling(duration.TotalSeconds);
		var days = totalSeconds / 86400;
		totalSeconds -= days * 86400;
		var hours = totalSeconds / 3600;
		totalSeconds -= hours * 3600;
		var minutes = totalSeconds / 60;
		var seconds = totalSeconds - (minutes * 60);
		return $"{days:00}:{hours:00}:{minutes:00}:{seconds:00}";
	}

	private static DbStats? TryReadDbStats(string qualifiedTableName)
	{
		try
		{
			var csb = new NpgsqlConnectionStringBuilder();
			ExampleDbConnection.Configure(csb);
			using var conn = new NpgsqlConnection(csb.ConnectionString);
			conn.Open();

			using var cmd = conn.CreateCommand();
			cmd.CommandText =
				$"SELECT COUNT(*), COALESCE(pg_total_relation_size(@table_name::regclass), 0) FROM {BenchmarkQualifiedTableName}";
			cmd.Parameters.AddWithValue("table_name", qualifiedTableName);

			using var reader = cmd.ExecuteReader();
			if (!reader.Read())
				return null;

			return new DbStats
			{
				RowCount = reader.GetInt64(0),
				TotalRelationBytes = reader.GetInt64(1)
			};
		}
		catch
		{
			return null;
		}
	}
}
