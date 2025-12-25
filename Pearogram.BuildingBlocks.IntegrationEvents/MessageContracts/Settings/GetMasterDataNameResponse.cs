namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Settings;

public record GetMasterDataNameResponse(Guid Id, string? Name,string? Color, bool Found);
