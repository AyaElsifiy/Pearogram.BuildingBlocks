using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.ImagePath;

public class GetAttachmentPathRequest : IIntegrationEvent
{
    public Guid UserId { get; set; }
    public string EntityType { get; set; } = string.Empty;

    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime OccurredOn { get; set; } = DateTime.UtcNow;
}
