using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using PP.Integrator;

namespace BenchCounters;

[MemoryDiagnoser]
public class AutoWaitFocusedBenchmarkDotNet
{
	private ILoggerFactory _factory = default!;
	private ILogger[] _mixedTableLoggers = default!;
	private IDisposable[] _mixedTableScopes = default!;
	private BenchmarkPayload[] _payloads = default!;
	private ILogger _singleTableLogger = default!;
	private IDisposable _singleTableScope = default!;

	[Params(10_000)]
	public int Operations { get; set; }

	[Benchmark]
	public void AutoWaitMixedTablesSimple()
	{
		for (var i = 0; i < Operations; i++)
			_mixedTableLoggers[i & 3].LogInformation("BDN autowait mixed-table message {Index}", i);
	}

	[Benchmark]
	public void AutoWaitSingleTableHeavyState()
	{
		for (var i = 0; i < Operations; i++)
		{
			var payload = _payloads[i & 63];
			_singleTableLogger.LogInformation("BDN autowait payload {PayloadId} tags {TagsCount} checksum {Checksum} details {Payload}", payload.Id, payload.Tags.Length, payload.Checksum, payload);
		}
	}

	[Benchmark(Baseline = true)]
	public void AutoWaitSingleTableSimple()
	{
		for (var i = 0; i < Operations; i++)
			_singleTableLogger.LogInformation("BDN autowait single-table message {Index}", i);
	}

	[GlobalCleanup]
	public void Cleanup()
	{
		foreach (var scope in _mixedTableScopes)
			scope.Dispose();

		_singleTableScope.Dispose();
		_factory.Dispose();
	}

	private ILogger[] CreateMixedTableLoggers() => new[]
	{
		_factory.CreateLogger("bdn-autowait-mixed-0"),
		_factory.CreateLogger("bdn-autowait-mixed-1"),
		_factory.CreateLogger("bdn-autowait-mixed-2"),
		_factory.CreateLogger("bdn-autowait-mixed-3")
	};

	private IDisposable[] CreateMixedTableScopes() => new[]
	{
		_mixedTableLoggers[0].BeginScope("logs_benchmark"),
		_mixedTableLoggers[1].BeginScope("logs_benchmark_alt1"),
		_mixedTableLoggers[2].BeginScope("logs_benchmark_alt2"),
		_mixedTableLoggers[3].BeginScope("logs_benchmark_alt3")
	};

	[GlobalSetup]
	public void Setup()
	{
		_factory = LoggerFactory.Create(builder =>
		{
			builder.ClearProviders();
			builder.AddPostgreLogger(ExampleDbConnection.Configure);
			builder.UseAutoWait();
		});

		_singleTableLogger = _factory.CreateLogger("bdn-autowait-single-table");
		_singleTableScope = _singleTableLogger.BeginScope("logs_benchmark");
		_mixedTableLoggers = CreateMixedTableLoggers();
		_mixedTableScopes = CreateMixedTableScopes();
		_payloads = Enumerable.Range(0, 64).Select(BenchmarkPayload.Create).ToArray();
	}
}
