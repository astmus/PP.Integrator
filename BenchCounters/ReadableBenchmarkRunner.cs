using System.Linq;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

namespace BenchCounters;

internal static class ReadableBenchmarkRunner
{
	public static Summary Run<TBenchmark>() where TBenchmark : class =>
		Run(typeof(TBenchmark));

	public static Summary Run(Type benchmarkType)
	{
		var summary = BenchmarkRunner.Run(benchmarkType, CreateConfig());
		WriteSummaryTable(summary);
		return summary;
	}

	private static void WriteSummaryTable(Summary summary)
	{
		var log = ConsoleLogger.Default;
		log.WriteLine();
		MarkdownExporter.Console.ExportToLog(summary, log);
	}

	private static IConfig CreateConfig()
	{
		var baseConfig = DefaultConfig.Instance;
		var config = ManualConfig.CreateEmpty();
		config.AddColumnProvider(baseConfig.GetColumnProviders().ToArray());
		config.AddExporter(baseConfig.GetExporters().ToArray());
		config.AddAnalyser(baseConfig.GetAnalysers().ToArray());
		config.AddValidator(baseConfig.GetValidators().ToArray());
		config.Orderer = baseConfig.Orderer;
		config.CategoryDiscoverer = baseConfig.CategoryDiscoverer;
		config.ArtifactsPath = baseConfig.ArtifactsPath;
		config.CultureInfo = baseConfig.CultureInfo;
		config.SummaryStyle = baseConfig.SummaryStyle;
		config.Options = baseConfig.Options | ConfigOptions.DisableLogFile;
		config.BuildTimeout = baseConfig.BuildTimeout;
		config.WakeLock = baseConfig.WakeLock;
		config.AddLogger(new ImportantOnlyLogger());
		config.AddJob(CreateBenchmarkJob());

		config.HideColumns(
			Column.Namespace,
			Column.Type,
			Column.Job,
			Column.StdErr,
			Column.StdDev,
			Column.Error,
			//Column.Min,
			Column.Q1,
			//Column.Median,
			Column.Q3,
			//Column.Max,
			Column.Skewness,
			Column.Kurtosis,
			Column.MValue,
			//Column.Iterations,
			Column.P0,
			Column.P25,
			Column.P50,
			Column.P67,
			Column.P80,
			Column.P85,
			Column.P90,
			Column.P95,
			Column.P100,
			Column.Categories,
			Column.LogicalGroup,
			Column.Rank,
			Column.RatioSD
			//Column.AllocRatio
			//Column.Gen0,
			//Column.Gen1,
			//Column.Gen2
			);

		return config;
	}

	private static Job CreateBenchmarkJob() =>
		Job.ShortRun.UnfreezeCopy()
			.WithIterationTime(TimeInterval.FromSeconds(6))
			.WithWarmupCount(1)
			.WithIterationCount(3)
			.Freeze();

	private sealed class ImportantOnlyLogger : BenchmarkDotNet.Loggers.ILogger
	{
		private readonly BenchmarkDotNet.Loggers.ILogger _inner = ConsoleLogger.Unicode;

		public string Id => nameof(ImportantOnlyLogger);

		public int Priority => 100;

		public void Write(LogKind logKind, string text)
		{
			if (logKind is LogKind.Error or LogKind.Warning or LogKind.Hint)
				_inner.Write(logKind, text);
		}

		public void WriteLine() { }

		public void WriteLine(LogKind logKind, string text)
		{
			if (logKind is LogKind.Error or LogKind.Warning or LogKind.Hint)
				_inner.WriteLine(logKind, text);
		}

		public void Flush() => _inner.Flush();
	}
}
