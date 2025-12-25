using Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Notifications;

namespace Pearogram.BuildingBlocks.Persistence.Contracts
{
    public interface IRoleService
    {
        Task<List<GetRolesToReturnDto>> GetRoles();
    }
}
