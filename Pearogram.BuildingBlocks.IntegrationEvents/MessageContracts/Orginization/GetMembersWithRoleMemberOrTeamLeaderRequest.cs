using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization;

public class GetMembersWithRoleMemberOrTeamLeaderRequest : IIntegrationEvent
{
    public Guid Id { get; }
    public DateTime OccurredOn { get; }
}
