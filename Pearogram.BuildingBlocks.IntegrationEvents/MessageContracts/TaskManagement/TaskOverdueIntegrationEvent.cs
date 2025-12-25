using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;

public sealed record TaskOverdueIntegrationEvent : IIntegrationEvent
{
    public TaskOverdueIntegrationEvent(Guid taskId, string title, Guid? assigneeId, Guid? teamId, DateTime? dueDate)
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
        TaskId = taskId;
        Title = title;
        AssigneeId = assigneeId;
        TeamId = teamId;
        DueDate = dueDate;
    }

    public Guid Id { get; }
    public DateTime OccurredOn { get; }

    public Guid TaskId { get; }
    public string Title { get; }
    public Guid? AssigneeId { get; }
    public Guid? TeamId { get; }
    public DateTime? DueDate { get; set; }

}