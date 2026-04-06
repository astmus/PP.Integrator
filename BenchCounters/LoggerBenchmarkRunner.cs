namespace BenchCounters;

public static class LoggerBenchmarkRunner
{
	public static void RunBenchmarkDotNet() => ReadableBenchmarkRunner.Run<LoggerBenchmarkDotNet>();
}
