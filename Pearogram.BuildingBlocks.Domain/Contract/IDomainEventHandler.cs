using Pearogram.BuildingBlocks.Domain.Events;

namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
{
    Task Handle(TEvent domainEvent, CancellationToken cancellationToken);
}
