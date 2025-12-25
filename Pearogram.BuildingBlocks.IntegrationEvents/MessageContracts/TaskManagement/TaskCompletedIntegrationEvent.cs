using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;
using System.Collections.Immutable;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;


public sealed class TaskCompletedIntegrationEvent : IIntegrationEvent
{
    public TaskCompletedIntegrationEvent(Guid taskId, string title, List<Tuple<EPredefinedRolesEnum, List<Guid>>> listRoleUsers)
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
        TaskId = taskId;
        Title = title;
        ListRoleUsers = listRoleUsers;
    }

    public Guid Id { get; }
    public DateTime OccurredOn { get; }
    public Guid TaskId { get; }
    public string Title { get; }
    public List<Tuple<EPredefinedRolesEnum, List<Guid>>> ListRoleUsers { get; }
}
