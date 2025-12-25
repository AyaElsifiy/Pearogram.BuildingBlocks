using Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization;

namespace Pearogram.BuildingBlocks.Application.IMessaging.Organization;

public interface IUserServiceClient
{
    //Task<string?> GetUserName(Guid? userId);
    Task<DateTime?> GetUserLastLoginDate(Guid? userId);
    Task<List<UserListDto>> GetMembersWithRoleMemberOrTeamLeader();
}
