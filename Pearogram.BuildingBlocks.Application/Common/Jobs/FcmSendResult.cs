namespace Pearogram.BuildingBlocks.Application.Common.Jobs;

public sealed class FcmSendResult
{
    public FcmSendResult()
    {
        InvalidTokens = Array.Empty<string>();
    }
    public bool AnySuccess { get; init; }
    public int SuccessCount { get; init; }
    public int FailureCount { get; init; }
    public IReadOnlyList<string> InvalidTokens { get; init; }
    public string? AggregatedError { get; init; }
}