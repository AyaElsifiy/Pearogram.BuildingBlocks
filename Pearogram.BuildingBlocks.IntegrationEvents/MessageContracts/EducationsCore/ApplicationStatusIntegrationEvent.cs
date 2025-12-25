using Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.EducationsCore;

public class ApplicationStatusIntegrationEvent : IIntegrationEvent
{
    protected ApplicationStatusIntegrationEvent(string email, string phone, string name, 
        Guid applicationId, Guid parentId)
    {
        Email = email;
        Phone = phone;
        Name = name;
        ApplicationId = applicationId;
        ParentId = parentId;
    }

    public Guid Id => Guid.NewGuid();

    public DateTime OccurredOn => DateTime.UtcNow;
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Name { get; set; }
    public Guid ApplicationId { get; set; }
    public Guid ParentId { get; set; }

}
