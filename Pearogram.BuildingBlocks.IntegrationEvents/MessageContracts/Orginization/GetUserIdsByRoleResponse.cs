namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization;

public record GetUserIdsByRoleResponse
{
    public List<Guid>? UserIds { get; set; }
}
