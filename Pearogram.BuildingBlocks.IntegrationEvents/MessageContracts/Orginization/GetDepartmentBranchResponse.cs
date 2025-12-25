namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization;

public record GetDepartmentBranchResponse(Guid DepartmentId, Guid BranchId, string BranchName);
