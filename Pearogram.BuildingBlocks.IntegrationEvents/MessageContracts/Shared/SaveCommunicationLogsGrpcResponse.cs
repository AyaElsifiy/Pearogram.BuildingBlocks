namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Shared;

public class SaveCommunicationLogsGrpcResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
}
