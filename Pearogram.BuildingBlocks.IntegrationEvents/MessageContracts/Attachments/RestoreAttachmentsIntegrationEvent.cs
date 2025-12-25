using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Attachments
{
    public class RestoreAttachmentsIntegrationEvent : IIntegrationEvent
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime OccurredOn { get; set; } = DateTime.UtcNow;
        public Guid EntityId { get; set; }
        public string EntityType { get; set; } = string.Empty;
    }
}
