namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Orginization;

public record CheckUserUniquenessResponse(
    bool EmailExists,
    bool PhoneExists
);