using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;

public sealed class TaskUpdatedIntegrationEvent : IIntegrationEvent
{
    public TaskUpdatedIntegrationEvent(Guid taskId, string title, Guid? assigneeId)
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
        TaskId = taskId;
        Title = title;
        AssigneeId = assigneeId;
    }
    public Guid Id { get; }
    public DateTime OccurredOn { get; }
    public Guid TaskId { get; }
    public string Title { get; }
    public Guid? AssigneeId { get; }
}
