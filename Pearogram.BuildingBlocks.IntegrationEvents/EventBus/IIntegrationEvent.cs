namespace Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

public interface IIntegrationEvent
{
    Guid Id { get; }
    DateTime OccurredOn { get; } //Change this for DateTimeOffset
    // DateTimeOffset OccurredOn { get; }
}
