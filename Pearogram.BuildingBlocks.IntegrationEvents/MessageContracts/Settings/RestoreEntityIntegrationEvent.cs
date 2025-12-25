using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Settings;

public class RestoreEntityIntegrationEvent : IIntegrationEvent
{
    public Guid EntityId { get; set; }
    public EEntityType EntityType { get; set; }
    public EModuleType ModuleType { get; set; }
    public Guid Id { get; set; }
    public DateTime OccurredOn { get; set; }
}
