using Pearogram.BuildingBlocks.Domain.Enums;
using Pearogram.BuildingBlocks.Domain.Translation;
using Pearogram.BuildingBlocks.Domain.Validator;

namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface ITranslationService
{
    //Task SaveTranslationsAsync<T>(T entity, ELanguageCode languageCode) where T : class, ITranslatableEntity;
    //Task ApplyTranslationsAsync<T>(T entity, ELanguageCode languageCode) where T : class, ITranslatableEntity;
    //Task ApplyTranslationsAsync<T>(IEnumerable<T> entities, ELanguageCode languageCode) where T : class, ITranslatableEntity;
    //Task<Dictionary<string, string>> GetTranslationsAsync(EEntityType entityType, Guid entityId, ELanguageCode languageCode);

    Task<List<TranslationRowDto>> GetTranslationByEntityType(GetTranslationQuery request, CancellationToken cancellationToken);
    Task<Result<bool>> UpsertTranslation(TranslationUpsert request, CancellationToken cancellationToken);
    Task<Dictionary<string, string>> GetTranslationsAsync(EEntityType entityType, Guid entityId, ELanguageCode languageCode, CancellationToken ct = default);

    Task SaveTranslationsAsync<T>(T entity, ELanguageCode languageCode, CancellationToken ct = default)
        where T : class, ITranslatableEntity;

    Task ApplyTranslationsAsync<T>(T entity, ELanguageCode languageCode, CancellationToken ct = default)
        where T : class, ITranslatableEntity;

    Task ApplyTranslationsAsync<T>(IEnumerable<T> entities, ELanguageCode languageCode, CancellationToken ct = default)
        where T : class, ITranslatableEntity;

    Task ApplyTranslationsToDtosAsync<TDto>(IEnumerable<TDto> dtos, ELanguageCode languageCode, CancellationToken ct = default)
        where TDto : class, ITranslatable;

    Task UpsertBatchAsync(IEnumerable<(string field, ELanguageCode lang, string value)> items, EEntityType type, Guid id, CancellationToken ct = default);
}
