namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Shared;

public class CreateUserAccountResponse
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public Guid? UserId { get; set; }
    public Dictionary<string, string[]>? Errors { get; set; }
}
