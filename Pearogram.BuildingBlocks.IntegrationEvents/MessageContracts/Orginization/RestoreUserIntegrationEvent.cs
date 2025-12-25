using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization;

public class RestoreUserIntegrationEvent : IIntegrationEvent
{

    public Guid Id { get; set; }

    public DateTime OccurredOn { get; set; }

    public RestoreUserIntegrationEvent(Guid id)
    {
        Id = id;
    }
}
