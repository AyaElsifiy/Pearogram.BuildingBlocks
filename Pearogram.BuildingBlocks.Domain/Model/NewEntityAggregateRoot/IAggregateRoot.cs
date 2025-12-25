using Pearogram.BuildingBlocks.Domain.Events;

namespace Pearogram.BuildingBlocks.Domain.Model.NewEntityAggregateRoot;

// This name is better than Aggregate
public interface IAggregateRoot : INewEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void ClearDomainEvents();
}