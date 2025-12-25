namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;

public record GetCompanyUserResponse(Guid? CompanyId,string? CompanyName, string? Error)
{

}
