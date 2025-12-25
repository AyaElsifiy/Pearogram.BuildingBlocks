using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization;

public class GetRoleIdByEnumIdRequest
{
    public GetRoleIdByEnumIdRequest(EPredefinedRolesEnum role)
    {
        Role = role;
    }

    public EPredefinedRolesEnum Role { get; }
}
