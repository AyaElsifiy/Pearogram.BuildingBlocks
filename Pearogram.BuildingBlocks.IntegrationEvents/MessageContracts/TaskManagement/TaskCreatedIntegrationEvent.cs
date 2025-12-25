using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;

public sealed class TaskCreatedIntegrationEvent : IIntegrationEvent
{
    public TaskCreatedIntegrationEvent(Guid taskId, string title, Guid? assigneeId, DateTime? dueDate)
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
    public Guid TaskId { get; }
    public string Title { get; }
    public Guid? AssigneeId { get; }
    public DateTime? DueDate { get; set; } //Change this for DateTimeOffset
    //public DateTimeOffset? DueDate { get; set; }
}

//Why did we create an interface + class?
//Consumers bind to Interface v1 (static), and the publisher can easily change the class or access v2 later without breaking the consumers.

//New Interface
//public interface ITaskCreatedIntegrationEvent_v1 : IIntegrationEvent
//{
//    Guid TaskId { get; }
//    string Title { get; }
//    Guid? AssigneeId { get; }
//    DateTimeOffset? DueDate { get; }
//}

//New Class
//public sealed class TaskCreatedIntegrationEvent_v1 : ITaskCreatedIntegrationEvent_v1
//{
//    public TaskCreatedIntegrationEvent_v1(Guid taskId, string title, Guid? assigneeId, DateTimeOffset? dueDate)
//    {
//        Id = Guid.NewGuid();
//        OccurredOn = DateTimeOffset.UtcNow;
//        TaskId = taskId;
//        Title = title;
//        AssigneeId = assigneeId;
//        DueDate = dueDate;
//    }

//    public Guid Id { get; }
//    public DateTimeOffset OccurredOn { get; }
//    public Guid TaskId { get; }
//    public string Title { get; }
//    public Guid? AssigneeId { get; }
//    public DateTimeOffset? DueDate { get; }
//}