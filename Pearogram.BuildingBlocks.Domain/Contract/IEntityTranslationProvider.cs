using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.Domain.Translation;

namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface IEntityTranslationProvider
{
    EEntityType EntityType { get; }

    Task<IReadOnlyList<TranslatableFieldValue>> GetForEntityAsync(Guid entityId, CancellationToken ct = default);
}