using Pearogram.BuildingBlocks.Domain.Events;

namespace Pearogram.BuildingBlocks.Domain.Model;

//we don't need that ever, must be deleted
public abstract class Aggregate : Entity, IAggregate
{
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;


    private readonly List<IDomainEvent> _domainEvents = new();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent); 
    }
    public void ClearDomainEvents() => _domainEvents.Clear();
}
