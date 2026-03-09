namespace BenchCounters;

internal sealed record NestedPayload(string Tenant, string Source, DateTimeOffset CreatedAt, bool IsEnabled);
