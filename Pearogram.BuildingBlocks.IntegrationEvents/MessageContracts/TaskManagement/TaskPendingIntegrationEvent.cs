using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;
public sealed class TaskPendingIntegrationEvent : IIntegrationEvent
{
    public TaskPendingIntegrationEvent(Guid taskId, string title, Guid? assigneeId, DateTime? dueDate)
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
        TaskId = taskId;
        Title = title;
        AssigneeId = assigneeId;
        DueDate = dueDate;
    }

    public Guid Id { get; }
    public DateTime OccurredOn { get; }
    public DateTime? DueDate { get; }
    public Guid TaskId { get; }
    public string Title { get; }
    public Guid? AssigneeId { get; }
}
