namespace Pearogram.BuildingBlocks.Domain.Model.NewEntityAggregateRoot;

// When we use this class, we must to rename it to (Entity)
public abstract class NewEntity : INewEntity
{
    protected NewEntity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; protected set; }
    public DateTimeOffset CreatedAt { get; protected set; }
    public Guid CreatedBy { get; protected set; }
    public DateTimeOffset? DeletedAt { get; protected set; }
    public Guid? DeletedBy { get; protected set; }
    public bool IsArchive { get; protected set; }
    public bool IsDeleted { get; protected set; }
    public DateTimeOffset? UpdatedAt { get; protected set; }
    public Guid? UpdatedBy { get; protected set; }

    public void Archive()
          => IsArchive = true;
    public void Unarchive()
        => IsArchive = false;
    protected void MarkUpdated(Guid userId)
    {
        UpdatedBy = userId;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
    protected void MarkCreated(Guid userId)
    {
        CreatedBy = userId;
        CreatedAt = DateTimeOffset.UtcNow;
    }
    protected void MarkDeleted(Guid userId)
    {
        IsDeleted = true;
        DeletedBy = userId;
        DeletedAt = DateTimeOffset.UtcNow;
    }
}



//Example for using this methods if we want
//public void RenameDepartment(string newName, Guid userId)
//    {
//        if (string.IsNullOrWhiteSpace(newName))
//            throw new BusinessRuleException("Name is required.");

//        Name = newName.Trim();
//        MarkUpdated(userId); //Here..
//    }