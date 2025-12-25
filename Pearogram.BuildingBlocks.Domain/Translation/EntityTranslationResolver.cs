using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pearogram.BuildingBlocks.Domain.Contract;
using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.Domain.Translation;

public class EntityTranslationResolver : IEntityTranslationResolver
{
    private readonly IServiceProvider _serviceProvider;
    // EntityType → (ClrType, DbContextType)
    private readonly Dictionary<EEntityType, (Type ClrType, Type DbContextType)> _map;

    public EntityTranslationResolver(IEnumerable<TranslationRegistration> registrations, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        var duplicates = registrations
        .GroupBy(r => r.EntityType)
        .Where(g => g.Count() > 1)
        .Select(g => $"{g.Key} ({g.Count()} registrations)")
        .ToList();

        if (duplicates.Any())
        {
            throw new InvalidOperationException(
                $"Duplicate TranslationRegistration found for EEntityType: {string.Join(", ", duplicates)}. " +
                "Each EEntityType must be registered exactly once.");
        }

        _map = registrations.ToDictionary(r => r.EntityType, r => (r.ClrType, r.DbContextType));
    }

    /// <summary>
    /// Returns a provider bound to the correct DbContext and CLR type for the requested entity type.
    /// </summary>
    public IEntityTranslationProvider? Resolve(EEntityType entityType)
    {
        if (!_map.TryGetValue(entityType, out var tuple))
            return null;

        var (clrType, dbCtxType) = tuple;

        // Resolve the right DbContext instance from DI
        var db = (DbContext)_serviceProvider.GetRequiredService(dbCtxType);

        // Make GenericTranslationProvider<TEntity> where TEntity = clrType
        var providerType = typeof(GenericTranslationProvider<>).MakeGenericType(clrType);

        return (IEntityTranslationProvider)Activator.CreateInstance(providerType, db, entityType)!;
    }

    /// <summary>
    /// Retrieves the CLR <see cref="Type"/> that corresponds to a given <see cref="EEntityType"/>.
    /// </summary>
    public Type? GetClrType(EEntityType entityType)
        => _map.TryGetValue(entityType, out var tuple) ? tuple.ClrType : null;
}
