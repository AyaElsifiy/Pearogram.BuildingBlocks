using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.Domain.Translation;

public sealed record TranslationRegistration(
    EEntityType EntityType,
    Type ClrType,
    Type DbContextType
);
