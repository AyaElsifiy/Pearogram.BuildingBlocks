using MediatR;

namespace Pearogram.BuildingBlocks.Domain.Events;

public abstract record DomainEvent : IDomainEvent
{
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
}
