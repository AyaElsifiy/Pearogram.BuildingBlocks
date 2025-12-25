using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;
public sealed record TaskAssignedIntegrationEvent
        : IIntegrationEvent
{
    public TaskAssignedIntegrationEvent(Guid taskId, string title, Guid? assigneeId, Guid? teamId)
    {
        TaskId = taskId;
        Title = title;
        AssigneeId = assigneeId;
        TeamId = teamId;
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public Guid? AssigneeId { get; set; }
    public Guid? TeamId { get; set; }
    public Guid Id { get; set; }
    public DateTime OccurredOn { get; set; }
}
