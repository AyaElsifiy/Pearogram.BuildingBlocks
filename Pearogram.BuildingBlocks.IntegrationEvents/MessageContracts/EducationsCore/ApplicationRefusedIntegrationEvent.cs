namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.EducationsCore;
public class ApplicationRefusedIntegrationEvent : ApplicationStatusIntegrationEvent
{
    public string? RefuseReason { get; set; }
    public ApplicationRefusedIntegrationEvent(string email, string phone, string name,
        Guid applicationId, Guid parentId, string? refuseReason) : base(email, phone, name, applicationId, parentId)
    {
        RefuseReason = refuseReason;
    }
}
