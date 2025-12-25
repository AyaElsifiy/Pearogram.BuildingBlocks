namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization;


public class GetRolesResponse
{
    public List<RoleDto>? Roles { get; set; }
}
public class RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}