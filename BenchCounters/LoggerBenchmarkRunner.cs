using System.Diagnostics;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Running;
using Npgsql;
using PP.Integrator;

namespace BenchCounters;

public static class LoggerBenchmarkRunner
{
	private const string BenchmarkScopeName = "benchmark";
	private const string BenchmarkSchemaName = "logs";
	private const string BenchmarkQualifiedTableName = $"{BenchmarkSchemaName}.{BenchmarkScopeName}";
	private static readonly TimeSpan WarmupWindow = TimeSpan.FromSeconds(5);
	private static readonly TimeSpan BenchmarkWindow = TimeSpan.FromSeconds(6);
	private static readonly TimeSpan CountersWindow = WarmupWindow + BenchmarkWindow + TimeSpan.FromSeconds(5);
	private static bool _environmentPrinted;

	private static readonly string[] units = new[] { "B", "KB", "MB", "GB", "TB" };
	private static string FormatBytes(long bytes)
	{
		var value = Math.Abs((double)bytes);
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

	private static double GetMeanUsPerOp(ScenarioResult result) => result.Messages > 0 ? result.DurationMs * 1000.0 / result.Messages : 0;

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
		Console.WriteLine($"Process id: {Environment.ProcessId}");
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
		Warmup(logger, title);

		var sw = Stopwatch.StartNew();
		int messages = 0;
		Exception ex = new ArgumentException("test exception", $"benchmark-{title}");

		using (var scope = logger.BeginScope(BenchmarkScopeName))
		{
			while (sw.Elapsed < BenchmarkWindow)
			{
				logger.LogInformation((EventId)messages, ex, "Benchmark mode={Mode} index={Index}", title, messages);
				messages++;
			}
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
		Console.WriteLine("Running comparison with warmup. dotnet-counters starts before warmup so the main measurement window is visible in the counters output.");
		var readWhileWrite = RunScenarioWithCounters(builder => builder.UseClassic(), "read-while-write");
		var autoWait = RunScenarioWithCounters(builder => builder.UseAutoWait(), "autowait");
		PrintComparison(readWhileWrite, autoWait);
	}

	private static void StartCountersSidecar(string title)
	{
		var durationArg = ToDurationArg(CountersWindow);
		var pid = Environment.ProcessId;

		if (!ToolExists("dotnet-counters"))
		{
			Console.WriteLine($"[{title}] dotnet-counters was not found in PATH. Install it with 'dotnet tool install -g dotnet-counters' or add a local tool manifest.");
			Console.WriteLine($"[{title}] Manual command: dotnet-counters monitor --process-id {pid} --counters System.Runtime --refresh-interval 1 --duration {durationArg} --showDeltas");
			return;
		}

		try
		{
			var psi = OperatingSystem.IsWindows()
				? CreateWindowsCountersStartInfo(pid, durationArg)
				: CreateDirectCountersStartInfo(pid, durationArg);
			var process = Process.Start(psi);
			if (process == null)
			{
				Console.WriteLine($"[{title}] dotnet-counters process was not created.");
				return;
			}

			Console.WriteLine($"[{title}] dotnet-counters started for pid={pid}, duration={durationArg}.");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"[{title}] Failed to start counters sidecar: {ex.Message}");
			Console.WriteLine($"[{title}] Manual command: dotnet-counters monitor --process-id {pid} --counters System.Runtime --refresh-interval 1 --duration {durationArg} --showDeltas");
		}
	}

	private static ProcessStartInfo CreateWindowsCountersStartInfo(int pid, string durationArg)
	{
		var args = BuildCountersArguments(pid, durationArg);
		var psi = new ProcessStartInfo
		{
			FileName = "cmd.exe",
			UseShellExecute = true,
			WorkingDirectory = AppContext.BaseDirectory
		};
		psi.ArgumentList.Add("/c");
		psi.ArgumentList.Add("start");
		psi.ArgumentList.Add("dotnet-counters");
		psi.ArgumentList.Add("dotnet-counters");
		foreach (var arg in args)
			psi.ArgumentList.Add(arg);

		return psi;
	}

	private static ProcessStartInfo CreateDirectCountersStartInfo(int pid, string durationArg)
	{
		var psi = new ProcessStartInfo
		{
			FileName = "dotnet-counters",
			UseShellExecute = true,
			WorkingDirectory = AppContext.BaseDirectory
		};
		foreach (var arg in BuildCountersArguments(pid, durationArg))
			psi.ArgumentList.Add(arg);

		return psi;
	}

	private static string[] BuildCountersArguments(int pid, string durationArg) =>
		new[]
		{
			"monitor",
			"--process-id",
			pid.ToString(),
			"--counters",
			"System.Runtime",
			"--refresh-interval",
			"1",
			"--duration",
			durationArg,
			"--showDeltas"
		};

	private static bool ToolExists(string toolName)
	{
		try
		{
			var psi = OperatingSystem.IsWindows()
				? new ProcessStartInfo
				{
					FileName = "where.exe",
					UseShellExecute = false,
					CreateNoWindow = true,
					RedirectStandardOutput = true,
					RedirectStandardError = true
				}
				: new ProcessStartInfo
				{
					FileName = "which",
					UseShellExecute = false,
					CreateNoWindow = true,
					RedirectStandardOutput = true,
					RedirectStandardError = true
				};
			psi.ArgumentList.Add(toolName);

			using var process = Process.Start(psi);
			if (process == null)
				return false;

			process.WaitForExit(3000);
			return process.ExitCode == 0;
		}
		catch
		{
			return false;
		}
	}

	private static void Warmup(ILogger logger, string title)
	{
		Console.WriteLine($"[{title}] Warmup started for {WarmupWindow.TotalSeconds:N0} s.");
		var sw = Stopwatch.StartNew();
		int messages = 0;

		using var scope = logger.BeginScope(BenchmarkScopeName);
		while (sw.Elapsed < WarmupWindow)
		{
			logger.LogInformation("Warmup mode={Mode} index={Index}", title, messages);
			messages++;
		}

		sw.Stop();
		Console.WriteLine($"[{title}] Warmup finished, sent {messages:N0} messages.");
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

			using var command = conn.CreateCommand();
			command.CommandText = $"ANALYZE {qualifiedTableName}";
			command.ExecuteNonQuery();

			using var cmd = conn.CreateCommand();
			cmd.CommandText = $"SELECT COUNT(*), COALESCE(pg_total_relation_size(@table_name::regclass), 0) FROM {qualifiedTableName}";
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
		catch (Exception ex)
		{
			Console.Error.WriteLine(ex.ToString());
			return null;
		}
	}
}
