namespace BenchCounters;

internal readonly record struct ScenarioResult(
	string Title,
	long Messages,
	double DurationMs,
	double LogsPerSecond,
	long RowsWritten,
	long DbBytesDelta,
	double AvgBytesPerAttempted,
	double AvgBytesPerInserted);
