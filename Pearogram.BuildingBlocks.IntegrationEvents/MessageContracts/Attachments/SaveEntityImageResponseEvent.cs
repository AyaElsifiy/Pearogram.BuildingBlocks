namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Attachments;

public class SaveEntityImageResponseEvent
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public Guid? Resource { get; set; }
    public string? Path { get; set; }
}
