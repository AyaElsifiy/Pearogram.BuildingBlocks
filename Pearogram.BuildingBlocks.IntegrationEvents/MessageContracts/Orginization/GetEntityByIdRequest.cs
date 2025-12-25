using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization;

public class GetEntityByIdRequest : IIntegrationEvent
{
    public GetEntityByIdRequest(Guid entityId, EEntityType entityType)
    {
        OccurredOn = DateTime.UtcNow;
        EntityId = entityId;
        EntityType = entityType;
    }
    public EEntityType EntityType { get; set; }
    public Guid EntityId { get; set; }

    public Guid Id { get; }

    public DateTime OccurredOn { get; }
}
