namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Settings;

public record EntityPermentlyDeletedIntegrationEventResponse(bool Success, string? ErrorMessage = "Error");
