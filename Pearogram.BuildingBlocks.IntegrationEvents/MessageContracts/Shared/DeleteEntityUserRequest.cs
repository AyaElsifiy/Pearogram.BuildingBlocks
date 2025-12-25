using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Shared;

public record DeleteEntityUserRequest(Guid UserId) : IIntegrationEvent
{
    public Guid Id { get; set; }
    public DateTime OccurredOn { get; set; }
}
