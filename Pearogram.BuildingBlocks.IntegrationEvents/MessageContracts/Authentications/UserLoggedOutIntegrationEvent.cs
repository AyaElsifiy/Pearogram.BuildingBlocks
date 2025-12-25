using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Authentications;

public sealed class UserLoggedOutIntegrationEvent : IIntegrationEvent
{
    public Guid UserId { get; init; }
    public string DeviceToken { get; set; } = string.Empty;

    public Guid Id => Guid.NewGuid();

    public DateTime OccurredOn => DateTime.UtcNow;
}
