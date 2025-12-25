namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Settings;

public record RestoreEntityResponse(bool Success,string? ErrorMessage="Error");
