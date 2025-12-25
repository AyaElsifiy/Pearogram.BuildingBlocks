using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface ITranslatable
{
    Guid Id { get; }               
    EEntityType GetEntityType();     
}
