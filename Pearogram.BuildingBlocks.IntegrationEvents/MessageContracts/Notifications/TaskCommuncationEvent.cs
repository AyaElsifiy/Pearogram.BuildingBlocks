using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Notifications;

public class TaskCommuncationEvent : IIntegrationEvent
{
    public TaskCommuncationEvent()
    {
        OccurredOn = DateTime.UtcNow;
    }

    public ECommunicationTypes CommuncationTypeEnum { get; set; }

    public string TaskTitle { get; set; } = string.Empty;

    public Guid TaskId { get; set; }

    //public string MessageBody { get; set; } = string.Empty;

    //public string Title { get; set; } = string.Empty;

    public EEntityType RefEntityType { get; set; }

    public Guid Id { get; }

    public DateTime OccurredOn { get; }
}