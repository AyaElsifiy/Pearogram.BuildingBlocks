namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;

public record GetUserNameAndImageRequest(Guid UserId, string BaseUrl);
