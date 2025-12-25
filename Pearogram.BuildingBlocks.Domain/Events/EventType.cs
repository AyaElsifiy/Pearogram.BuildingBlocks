namespace Pearogram.BuildingBlocks.Domain.Events;

[Flags]
public enum EventType
{
    IntegrationEvent = 1,
    DomainEvent = 2,
}
