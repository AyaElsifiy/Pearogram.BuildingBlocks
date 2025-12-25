using Pearogram.BuildingBlocks.Domain.Events;

namespace Pearogram.BuildingBlocks.Domain.Model;

public interface IAggregate
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void AddDomainEvent(IDomainEvent domainEvent);
    void ClearDomainEvents();
}
