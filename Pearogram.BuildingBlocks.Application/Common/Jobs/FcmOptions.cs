namespace Pearogram.BuildingBlocks.Application.Common.Jobs;

public sealed class FcmOptions
{
    public string ProjectId { get; set; } = default!;
    public string ServiceAccountPath { get; set; } = default!;
    public int MaxBatchSize { get; set; } = 500;
    public int MaxParallelBatches { get; set; } = 4;
    public int DefaultTtlSeconds { get; set; } = 3600;
    public string? AndroidChannelId { get; set; } = "high_importance_channel";
    public string? ApnsTopic { get; set; }
}
