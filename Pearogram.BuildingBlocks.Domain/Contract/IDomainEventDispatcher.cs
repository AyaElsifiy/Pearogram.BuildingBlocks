using Pearogram.BuildingBlocks.Domain.Events;

namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken);
}
