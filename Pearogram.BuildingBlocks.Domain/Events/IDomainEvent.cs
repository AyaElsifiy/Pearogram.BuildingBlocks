using MediatR;

namespace Pearogram.BuildingBlocks.Domain.Events;

public interface IDomainEvent : INotification
{
    DateTimeOffset OccurredOn { get; }
}
