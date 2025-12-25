using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Shared;

public class CreateUserAccountRequest : IIntegrationEvent
{
    public string Name { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public Guid RoleId { get; set; }
    public Guid CompanyId { get; set; }
    public string? Description { get; set; }
    public string? ImageBase64 { get; set; }
    public string? FileName { get; set; }
    public DateTime OccurredOn { get; set; }
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid  ApplicationId { get; set; }
}
