using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Notifications;

public record MessageTemplatesListRequestMessage(
    EChannelType ChannelType,
    ELanguageCode LanguageCode,
    Guid Id,
    DateTime OccurredOn
) : IIntegrationEvent;
