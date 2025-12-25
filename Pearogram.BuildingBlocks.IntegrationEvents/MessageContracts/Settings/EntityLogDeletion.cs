using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Settings;

public class EntityLogDeletion : IIntegrationEvent
{
    public EntityLogDeletion()
    {
        Name = string.Empty;
    }
    public EntityLogDeletion(Guid id, EEntityType eEntityType, EModuleType moduleType, string name,Guid deletedBy,DateTime deletedAt)
    {
        Id = id;
        EntityType = eEntityType;
        ModuleType = moduleType;
        Name = name;
        DeletedBy = deletedBy;
        DeletedAt = deletedAt;
    }
    public Guid Id { get; set; }
    public DateTime OccurredOn { get; set; }
    public EEntityType EntityType { get; set; }
    public EModuleType ModuleType { get; set; }
    public string Name { get; set; }
    public Guid DeletedBy { get; set; }
    public DateTime DeletedAt { get; set; }
}

