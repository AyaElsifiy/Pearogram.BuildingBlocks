using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface IEntityTranslationResolver
{
    IEntityTranslationProvider? Resolve(EEntityType entityType);
    Type? GetClrType(EEntityType entityType);
}
