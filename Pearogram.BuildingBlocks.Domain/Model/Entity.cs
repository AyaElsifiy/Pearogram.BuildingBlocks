using Pearogram.BuildingBlocks.Domain.Contract;
using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.Domain.Events;
using Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Settings;

namespace Pearogram.BuildingBlocks.Domain.Model;

public abstract class Entity : IEntity, IAggregate, ISoftDeletable
{
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;


    private readonly List<IDomainEvent> _domainEvents = new();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public void ClearDomainEvents() => _domainEvents.Clear();
    protected Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? DeletedBy { get; set; }
    public bool IsArchive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
    public void UpdateIsArchive(bool isArchive)
     => IsArchive = isArchive;
    public virtual void UpdateIsDelete(bool isDeleted)
       => IsDeleted = isDeleted;
    public void UpdateIsDelete(string name, EModuleType moduleType, Guid deletedBy)
    {
        Enum.TryParse(this.GetType().Name, out EEntityType entityType);
        UpdateIsDelete(true);

        AddDomainEvent(new EntityLogDeletionDomainEvent(this.Id, entityType, moduleType, name, deletedBy,
            DateTime.UtcNow));
        AddDomainEvent(new DeleteEntityAttachments(this.Id, entityType));
    }
    public void UpdateId(Guid id)
    {
        Id = id;
    }


}