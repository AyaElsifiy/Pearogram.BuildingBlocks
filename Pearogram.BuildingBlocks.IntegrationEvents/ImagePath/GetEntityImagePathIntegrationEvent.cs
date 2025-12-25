using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.ImagePath;

public class GetEntityImagePathIntegrationEvent : IIntegrationEvent
{
    public GetEntityImagePathIntegrationEvent(Guid userId, string entityType, string baseUrl)
    {
        UserId = userId;
        EntityType = entityType;
        BaseUrl = baseUrl;
    }
    public Guid UserId { get; }
    public string BaseUrl { get; }
    public string EntityType { get; set; }

    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime OccurredOn { get; set; } = DateTime.UtcNow;
}