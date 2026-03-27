using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using PP.Integrator;

namespace BenchCounters;

// Один вызов метода = запись ~6 с (как LoggerBenchmarkRunner.RunScenario).
[MemoryDiagnoser]
public class SustainedLoadBenchmarkDotNet
{
	private static readonly TimeSpan SustainedWindow = TimeSpan.FromSeconds(6);

	private IDisposable _autoWaitScope = default!;
	private ILogger _autoWaitLogger = default!;
	private ILoggerFactory _autoWaitFactory = default!;
	private IDisposable _classicScope = default!;
	private ILogger _classicLogger = default!;
	private ILoggerFactory _classicFactory = default!;
	private BenchmarkPayload[] _payloads = default!;

	[Benchmark(Baseline = true)]
	public void ReadWhileWriteSustained()
	{
		var sw = Stopwatch.StartNew();
		for (var i = 0; sw.Elapsed < SustainedWindow; i++)
		{
			var payload = _payloads[i & 63];
			_classicLogger.LogInformation("BDN sustained classic payload {PayloadId} tags {TagsCount} checksum {Checksum} details {Payload}", payload.Id, payload.Tags.Length, payload.Checksum, payload);
		}
	}

	[Benchmark]
	public void AutoWaitSustained()
	{
		var sw = Stopwatch.StartNew();
		for (var i = 0; sw.Elapsed < SustainedWindow; i++)
		{
			var payload = _payloads[i & 63];
			_autoWaitLogger.LogInformation("BDN sustained autowait payload {PayloadId} tags {TagsCount} checksum {Checksum} details {Payload}", payload.Id, payload.Tags.Length, payload.Checksum, payload);
		}
	}

	[GlobalCleanup]
	public void Cleanup()
	{
		_classicScope.Dispose();
		_autoWaitScope.Dispose();
		_classicFactory.Dispose();
		_autoWaitFactory.Dispose();
	}

	[GlobalSetup]
	public void Setup()
	{
		_classicFactory = LoggerFactory.Create(builder =>
		{
			builder.ClearProviders();
			builder.AddPostgreLogger(ExampleDbConnection.Configure);
			builder.UseClassic();
		});

		_autoWaitFactory = LoggerFactory.Create(builder =>
		{
			builder.ClearProviders();
			builder.AddPostgreLogger(ExampleDbConnection.Configure);
			builder.UseAutoWait();
		});

		_classicLogger = _classicFactory.CreateLogger("bdn-sustained-classic");
		_autoWaitLogger = _autoWaitFactory.CreateLogger("bdn-sustained-autowait");
		_classicScope = _classicLogger.BeginScope("logs_benchmark");
		_autoWaitScope = _autoWaitLogger.BeginScope("logs_benchmark");
		_payloads = Enumerable.Range(0, 64).Select(BenchmarkPayload.Create).ToArray();
	}
}
