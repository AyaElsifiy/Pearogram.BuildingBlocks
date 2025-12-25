using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization
{
    public class RestoreEntityByIdRequest : IIntegrationEvent
    {
        public RestoreEntityByIdRequest(Guid entityId, EEntityType entityType)
        {
            EntityId = entityId;
            EntityType = entityType;
            OccurredOn = DateTime.UtcNow;
        }

        public Guid EntityId { get; set; }
        public EEntityType EntityType { get; set; }
        public DateTime OccurredOn { get; }

        public Guid Id { get; }
    }

}
