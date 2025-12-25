using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.EducationsCore;

public class StudentDeletedIntegrationEvent : IIntegrationEvent
{
    public Guid Id { get; }
    public DateTime OccurredOn { get; }
    public Guid StudentId { get; set; }
    public Guid UserId { get; set; }
}
