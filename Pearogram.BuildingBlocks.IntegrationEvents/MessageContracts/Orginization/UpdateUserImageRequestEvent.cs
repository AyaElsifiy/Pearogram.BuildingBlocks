using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization;

public class UpdateUserImageRequestEvent : IIntegrationEvent
{
    public UpdateUserImageRequestEvent()
    {
        ImageBase64 = string.Empty;
        FileName = string.Empty;
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
        EntityType = EEntityType.User;
        IsMain = true;
    }
    public EEntityType EntityType { get; set; }
    public string FileName { get; set; }
    public Guid Id { get; }
    public string? ImageBase64 { get; set; }
    public string? ObjectName { get; set; }
    public DateTime OccurredOn { get; }
    public Guid UserId { get; set; }
    public bool IsMain { get; set; }
}
