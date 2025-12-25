using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;

public record GetCompanyUserRequest(Guid UserId) : IIntegrationEvent
{
    public Guid Id { get; set; }
    public DateTime OccurredOn { get; set; }
}
