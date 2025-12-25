namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization
{
    public class GetMembersWithRoleMemberOrTeamLeaderResponse
    {
       public List<UserListDto>? Users { get; set; }
    }
    public class UserListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
