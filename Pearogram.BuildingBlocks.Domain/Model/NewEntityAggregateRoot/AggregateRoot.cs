using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.Domain.Events;

namespace Pearogram.BuildingBlocks.Domain.Model.NewEntityAggregateRoot;

// This name is better than Aggregate
public abstract class AggregateRoot : NewEntity, IAggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

    protected void AddDomainEvent(IDomainEvent domainEvent)
       => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();

    protected abstract EEntityType EntityType { get; }

    public void SoftDelete(string name, EModuleType moduleType, Guid deletedBy)
    {
        MarkDeleted(deletedBy);

        AddDomainEvent(new EntityLogDeletionDomainEvent(
            Id,
            EntityType,
            moduleType,
            name,
            deletedBy,
            DateTime.UtcNow
        ));
    }
}