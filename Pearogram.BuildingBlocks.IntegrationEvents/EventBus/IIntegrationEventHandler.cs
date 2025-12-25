namespace Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

public interface IIntegrationEventHandler<in TIntegrationEvent>
    where TIntegrationEvent : IIntegrationEvent
{
    Task HandleAsync(TIntegrationEvent dto);
}


//New version

//public static class IntegrationEventHeaders
//{
//    public const string EventName = "eventName";
//    public const string EventVersion = "eventVersion";
//    public const string EventId = "eventId";
//    public const string OccurredAtUtc = "occurredAt";
//    public const string TenantId = "tenantId";
//    public const string ActorId = "actorId";
//    public const string CorrelationId = "correlationId";
//    public const string CausationId = "causationId";
//}