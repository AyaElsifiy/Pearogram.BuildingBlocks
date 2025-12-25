using Pearogram.BuildingBlocks.Domain.Events;

namespace Pearogram.BuildingBlocks.Persistence.Contracts;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IEnumerable<IDomainEvent> events, CancellationToken ct = default);
}
