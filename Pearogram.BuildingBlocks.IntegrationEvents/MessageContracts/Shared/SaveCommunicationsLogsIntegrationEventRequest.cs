using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Shared;

public class SaveCommunicationsLogsIntegrationEventRequest : IIntegrationEvent
{
    public Guid Id { get; set; }
    public List<Guid>? RolesIds { get; set; }
    public List<Guid>? UsersIds { get; set; }
    public string? ContactValue { get; set; }
    public DateTime OccurredOn { get; set; }
    public List<string> Parameters { get; set; } = new List<string>();
    public string? Email { get; set; }
    public ECommunicationTypes CommunicationType { get; set; }
    public EEntityType EntityType { get; set; }
    public EReceiverType ReceiverType { get; set; }

}
