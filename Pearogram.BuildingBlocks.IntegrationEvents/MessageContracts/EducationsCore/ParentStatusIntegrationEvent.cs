using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.EducationsCore;

public record ParentStatusIntegrationEvent(Guid ParentId) : IIntegrationEvent
{
    public Guid Id { get; set; }

    public DateTime OccurredOn { get; set; }
}
