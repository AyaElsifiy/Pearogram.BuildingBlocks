namespace Pearogram.BuildingBlocks.Domain.Events;

public record EntityDeletedDomainEvent(Guid Id, string Name) : DomainEvent;

