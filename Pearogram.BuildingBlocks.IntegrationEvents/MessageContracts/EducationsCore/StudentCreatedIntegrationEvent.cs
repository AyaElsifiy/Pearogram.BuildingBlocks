using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.EducationsCore;

public class StudentCreatedIntegrationEvent : IIntegrationEvent
{
    public Guid Id { get; }
    public DateTime OccurredOn { get; }
    public string FullName { get; set; } = default!;
    public Guid DepartmentId { get; set; }
    public Guid RoleId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

}
