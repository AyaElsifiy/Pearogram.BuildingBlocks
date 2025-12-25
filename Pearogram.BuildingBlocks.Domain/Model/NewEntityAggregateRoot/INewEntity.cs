namespace Pearogram.BuildingBlocks.Domain.Model.NewEntityAggregateRoot;

// When we use this interface, we must to rename it to (IEntity)
public interface INewEntity
{
    public Guid Id { get; }
    public Guid CreatedBy { get; }
    public DateTimeOffset CreatedAt { get; }
    public Guid? UpdatedBy { get; }
    public DateTimeOffset? UpdatedAt { get; }
    public bool IsDeleted { get; }
    public Guid? DeletedBy { get; }
    public DateTimeOffset? DeletedAt { get; }
    public bool IsArchive { get; }
}