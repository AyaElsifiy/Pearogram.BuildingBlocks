using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Notifications;

public class GetRolesToReturnDto
{
    public GetRolesToReturnDto()
    {
        Name = default!;
        Description = default!;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? EnumId { get; set; }
}
