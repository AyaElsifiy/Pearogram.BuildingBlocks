namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.EducationsCore;

public sealed class ApplicationWaitingListIntegrationEvent : ApplicationStatusIntegrationEvent
{
    public ApplicationWaitingListIntegrationEvent(string email, string phone, string name,
        Guid applicationId, Guid parentId) : base(email, phone, name, applicationId, parentId)
    {

    }
}
