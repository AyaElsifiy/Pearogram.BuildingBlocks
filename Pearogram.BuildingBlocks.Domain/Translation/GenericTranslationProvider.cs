using Microsoft.EntityFrameworkCore;
using Pearogram.BuildingBlocks.Domain.Attributes;
using Pearogram.BuildingBlocks.Domain.Contract;
using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.Domain.Translation;

public class GenericTranslationProvider<TEntity> : IEntityTranslationProvider 
    where TEntity : class, ITranslatable
{
    private readonly DbContext _db;

    public GenericTranslationProvider(DbContext dbContext, EEntityType entityType)
    {
        _db = dbContext;
        EntityType = entityType;
    }

    public EEntityType EntityType { get; }

    public async Task<IReadOnlyList<TranslatableFieldValue>> GetForEntityAsync(Guid entityId, CancellationToken ct = default)
    {
        var set = _db.Set<TEntity>();
        var entity = await set.FirstOrDefaultAsync(e => e.Id == entityId, ct);
        if (entity is null) return Array.Empty<TranslatableFieldValue>();

        var props = TranslationReflectionCache.GetTranslatableProps(typeof(TEntity));
        var vals = new List<TranslatableFieldValue>();
        foreach (var p in props)
        {
            vals.Add(new TranslatableFieldValue(
                p.Name,
                (p.GetValue(entity) as string) ?? string.Empty
            ));
        }
        return vals;
    }
}
