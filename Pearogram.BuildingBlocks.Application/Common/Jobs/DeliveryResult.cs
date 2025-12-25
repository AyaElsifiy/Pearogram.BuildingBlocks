namespace Pearogram.BuildingBlocks.Application.Common.Jobs;

public class DeliveryResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }

    public static DeliveryResult Ok() => new() { Success = true };
    public static DeliveryResult Fail(string message) => new() { Success = false, ErrorMessage = message };
}