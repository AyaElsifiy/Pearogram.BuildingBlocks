namespace Pearogram.BuildingBlocks.Domain.Model;

public abstract class BaseIdEntity : IEntity<Guid>
{
    public Guid Id { get; protected set; }
}
