namespace Pearogram.BuildingBlocks.Domain.Model;

public interface IEntity<T>
{
    T Id { get; }
}
