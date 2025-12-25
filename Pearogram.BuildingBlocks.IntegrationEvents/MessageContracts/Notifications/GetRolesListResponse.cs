namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Notifications;

public class GetRolesListResponse
{
    public GetRolesListResponse()
    {
        Roles = new List<GetRolesToReturnDto>();
    }
    public List<GetRolesToReturnDto> Roles { get; set; }
}

