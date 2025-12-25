namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization;

public class GetRolesForMembersResponse
{
    public List<MembersRolesDto> Roles { get; set; } = new List<MembersRolesDto>();
}

public class MembersRolesDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}