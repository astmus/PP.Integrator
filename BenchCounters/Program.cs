using PP.Integrator;

namespace BenchCounters;

public class Program
{
	private static bool HandleBenchmarkCommands(string[] args)
	{
		if (args.Length == 0)
			return false;

		switch (args[0].ToLowerInvariant())
		{
			case "bench-bdn":
				LoggerBenchmarkRunner.RunBenchmarkDotNet();
				return true;
			case "bench-bdn-autowait":
				LoggerBenchmarkRunner.RunAutoWaitFocusedBenchmarkDotNet();
				return true;
			case "bench-compare":
				LoggerBenchmarkRunner.RunComparison();
				return true;
			case "bench-new":
				LoggerBenchmarkRunner.RunAutoWait();
				return true;
			case "bench-old":
			case "bench-readwhilewrite":
				LoggerBenchmarkRunner.RunReadWhileWrite();
				return true;
			case "bench-run-autowait":
				LoggerBenchmarkRunner.RunAutoWaitDirect();
				return true;
			case "bench-run-readwhilewrite":
				LoggerBenchmarkRunner.RunReadWhileWriteDirect();
				return true;
			case "run-new":
				RunHost(builder => builder.UseAutoWait());
				return true;
			case "run-old":
			case "run-readwhilewrite":
				RunHost(builder => builder.UseClassic());
				return true;
		}

		return false;
	}

	public static void Main(string[] args)
	{
		if (HandleBenchmarkCommands(args))
		{
			Console.WriteLine("Bench completed press any key");
			Console.ReadKey();
			return;
		}

		var builder = Host.CreateApplicationBuilder();
		builder.Logging.AddPostgreLogger(ExampleDbConnection.Configure).UseClassic();
		builder.Services
			.AddHostedService<LoggingExampleSecond>()
			.AddHostedService<LoggingExampleTwoScopes>()
			.AddHostedService<LoggingExample>();
		var host = builder.Build();
		host.Run();
	}

	private static void RunHost(Action<ILoggingBuilder> useLoggerKind)
	{
		var builder = Host.CreateApplicationBuilder();
		builder.Logging.AddPostgreLogger(ExampleDbConnection.Configure).UseClassic();
		useLoggerKind(builder.Logging);
		builder.Services
			.AddHostedService<LoggingExampleSecond>()
			.AddHostedService<LoggingExampleTwoScopes>()
			.AddHostedService<LoggingExample>();
		var host = builder.Build();
		host.Run();
	}
}
