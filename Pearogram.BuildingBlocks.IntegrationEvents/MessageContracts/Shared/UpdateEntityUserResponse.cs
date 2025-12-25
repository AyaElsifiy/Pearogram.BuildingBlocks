namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Shared;

public class UpdateEntityUserResponse
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public Guid UserId { get; set; }
}
