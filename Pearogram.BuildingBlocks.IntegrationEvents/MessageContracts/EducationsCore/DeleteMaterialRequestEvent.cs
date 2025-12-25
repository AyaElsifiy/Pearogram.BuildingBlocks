using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.EducationsCore;

public class DeleteMaterialRequestEvent : IIntegrationEvent
{
    public DeleteMaterialRequestEvent()
    {
        OccurredOn = DateTime.UtcNow;
        EntityType = string.Empty;
    }
    public Guid Id { get; set; }
    public Guid EntityId { get; set; }
    public string EntityType { get; set; }

    public DateTime OccurredOn { get; }
}
