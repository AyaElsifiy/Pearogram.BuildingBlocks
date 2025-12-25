namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;

public class DeleteAllEntityFilesResponseEvent
{
    public bool Success { get; set; }
    public string? Message { get; set; }
}
