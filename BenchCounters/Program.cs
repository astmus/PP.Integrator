using PP.Integrator;
using System.Diagnostics;

namespace BenchCounters;

public class Program
{
	private enum StartMode
	{
		RunApp,
		BenchmarkExecuted,
		InvalidArgs
	}

	private static StartMode HandleBenchmarkCommands(string[] args)
	{
		if (args.Length == 0)
			return StartMode.RunApp;

		switch (args[0].ToLowerInvariant())
		{
			case "app":
				return StartMode.RunApp;
			case "bench":
				LoggerBenchmarkRunner.RunBenchmarkDotNet();
				return StartMode.BenchmarkExecuted;
		}

		PrintUsage(args[0]);
		return StartMode.InvalidArgs;
	}

	public static void Main(string[] args)
	{
		var startMode = HandleBenchmarkCommands(args);

		if (startMode == StartMode.BenchmarkExecuted)
		{
			Console.WriteLine("Bench completed press any key");
			Console.ReadKey();
			return;
		}

		if (startMode == StartMode.InvalidArgs)
			return;

		RunApplication();
	}

	private static void RunApplication()
	{
#if DEBUG
		StartDotNetCounters();
#endif

		var builder = Host.CreateApplicationBuilder();
		builder.Logging.ClearProviders();
		builder.Logging.AddPostgreLogger(ExampleDbConnection.Configure);
		builder.Services
			.AddHostedService<LoggingExampleSecond>()
			.AddHostedService<LoggingExampleTwoScopes>()
			.AddHostedService<LoggingExample>();
		var host = builder.Build();
		host.Run();

		Console.WriteLine("All completed press any key");
		Console.ReadKey(true);
	}

	private static void StartDotNetCounters()
	{
		foreach (var startInfo in GetDotNetCountersStartInfos())
		{
			try
			{
				Process.Start(startInfo);
				Console.WriteLine($"dotnet-counters started for PID={Environment.ProcessId}");
				return;
			}
			catch
			{
			}
		}

		Console.Error.WriteLine("Не удалось запустить dotnet-counters. Установите/обновите global tool: dotnet tool update --global dotnet-counters");
	}

	private static void PrintUsage(string providedArg)
	{
		Console.Error.WriteLine($"Unknown mode: '{providedArg}'.");
		Console.Error.WriteLine("Available modes:");
		Console.Error.WriteLine("  app       - run host application");
		Console.Error.WriteLine("  bench     - run MemoryDiagnoser benchmark for unified Postgre logger");
	}

	private static IEnumerable<ProcessStartInfo> GetDotNetCountersStartInfos()
	{
		var countersArgs = $"monitor --process-id {Environment.ProcessId}  --showDeltas";
		yield return new ProcessStartInfo
		{
			FileName = "dotnet-counters",
			Arguments = countersArgs,
			UseShellExecute = true,
			CreateNoWindow = false
		};

		var userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		if (string.IsNullOrWhiteSpace(userProfilePath))
			yield break;

		var globalToolPath = Path.Combine(userProfilePath, ".dotnet", "tools", "dotnet-counters.exe");
		if (!File.Exists(globalToolPath))
			yield break;

		yield return new ProcessStartInfo
		{
			FileName = globalToolPath,
			Arguments = countersArgs,
			UseShellExecute = true,
			CreateNoWindow = false
		};
	}
}
