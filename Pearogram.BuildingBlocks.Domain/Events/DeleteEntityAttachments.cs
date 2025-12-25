using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.Domain.Events;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Settings;

public record DeleteEntityAttachments(Guid Id, EEntityType EntityType) : DomainEvent
{

}
