using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.Domain.Events;

public sealed record EntityLogDeletionDomainEvent(
    Guid Id,
    EEntityType EntityType,
    EModuleType ModuleType,
    string Name,
    Guid deletedBy,
    DateTime deletedAt)
   : DomainEvent;
