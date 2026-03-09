namespace BenchCounters;

internal sealed record BenchmarkPayload(
	int Id,
	string Name,
	string Description,
	string[] Tags,
	int[] Values,
	NestedPayload Details,
	Guid CorrelationId,
	long Checksum)
{
	public static BenchmarkPayload Create(int index)
	{
		var tags = Enumerable.Range(0, 8).Select(tagIndex => $"tag-{index}-{tagIndex}").ToArray();
		var values = Enumerable.Range(index, 16).ToArray();
		return new BenchmarkPayload(
			index,
			$"payload-{index}",
			new string((char)('A' + (index % 26)), 192),
			tags,
			values,
			new NestedPayload($"tenant-{index % 4}", $"source-{index % 8}", DateTimeOffset.UtcNow.AddSeconds(-index), index % 2 == 0),
			Guid.NewGuid(),
			values.Aggregate(17L, (current, value) => (current * 31) + value));
	}
}
