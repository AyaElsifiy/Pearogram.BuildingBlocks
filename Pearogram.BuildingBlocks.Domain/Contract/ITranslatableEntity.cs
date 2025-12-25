using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface ITranslatableEntity
{
    Guid Id { get; }
    EEntityType GetEntityType();
}
