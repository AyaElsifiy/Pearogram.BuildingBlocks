using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;


public class DeleteAllEntityFilesRequestEvent : IIntegrationEvent
{
    public DeleteAllEntityFilesRequestEvent()
    {
        EntityType = string.Empty;
    }
    public Guid Id { get; set; }
    public string EntityType { get; set; }

    public DateTime OccurredOn { get; }
}
