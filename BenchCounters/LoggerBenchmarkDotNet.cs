using BenchmarkDotNet.Attributes;
using PP.Integrator;

namespace BenchCounters;

[MemoryDiagnoser]
public class LoggerBenchmarkDotNet
{
	private IDisposable _autoWaitScope = default!;
	private ILogger _autoWaitLogger = default!;
	private ILoggerFactory _autoWaitFactory = default!;
	private IDisposable _classicScope = default!;
	private ILogger _classicLogger = default!;
	private ILoggerFactory _classicFactory = default!;
	private BenchmarkPayload[] _payloads = default!;

	[Params(10_000)]
	public int Operations { get; set; }

	[Benchmark]
	public void AutoWait()
	{
		for (var i = 0; i < Operations; i++)
		{
			var payload = _payloads[i & 63];
			_autoWaitLogger.LogInformation("BDN autowait payload {PayloadId} tags {TagsCount} checksum {Checksum} details {Payload}", payload.Id, payload.Tags.Length, payload.Checksum, payload);
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

	[Benchmark(Baseline = true)]
	public void ReadWhileWrite()
	{
		for (var i = 0; i < Operations; i++)
		{
			var payload = _payloads[i & 63];
			_classicLogger.LogInformation("BDN classic payload {PayloadId} tags {TagsCount} checksum {Checksum} details {Payload}", payload.Id, payload.Tags.Length, payload.Checksum, payload);
		}
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

		_classicLogger = _classicFactory.CreateLogger("bdn-read-while-write");
		_autoWaitLogger = _autoWaitFactory.CreateLogger("bdn-autowait");
		_classicScope = _classicLogger.BeginScope("benchmark_c");
		_autoWaitScope = _autoWaitLogger.BeginScope("benchmark_a");
		_payloads = Enumerable.Range(0, 64).Select(BenchmarkPayload.Create).ToArray();
	}
}
