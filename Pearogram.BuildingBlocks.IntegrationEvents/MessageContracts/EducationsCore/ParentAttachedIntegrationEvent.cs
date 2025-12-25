using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.EducationsCore;
public class ParentAttachedIntegrationEvent : IIntegrationEvent
{
    public Guid Id { get; } = new Guid();
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
    public string FullName { get; set; } = default!;
    public Guid DepartmentId { get; set; }
    public Guid RoleId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

}