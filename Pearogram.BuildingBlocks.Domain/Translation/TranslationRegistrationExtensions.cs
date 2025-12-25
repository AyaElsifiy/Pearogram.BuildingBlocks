using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pearogram.BuildingBlocks.Domain.Contract;
using Pearogram.BuildingBlocks.Domain.Enums;
using System.Reflection;

namespace Pearogram.BuildingBlocks.Domain.Translation;

public static class TranslationRegistrationExtensions
{
    /// <summary>
    /// Registers a single (EEntityType → TEntity, TDbContext) mapping.
    /// </summary>
    public static IServiceCollection AddTranslationRegistration<TEntity, TDbContext>(
        this IServiceCollection services, EEntityType entityType)
        where TEntity : class, ITranslatable
        where TDbContext : DbContext
    {
        services.AddSingleton(new TranslationRegistration(entityType, typeof(TEntity), typeof(TDbContext)));
        return services;
    }

    /// <summary>
    /// Scans an assembly for ITranslatable types and registers them with a given DbContext.
    /// entityType is resolved by creating a private instance and calling GetEntityType().
    /// </summary>
    public static IServiceCollection AddTranslationRegistrationsFromAssembly<TDbContext>(
        this IServiceCollection services, Assembly assembly)
        where TDbContext : DbContext
    {
        var types = assembly.GetTypes()
            .Where(t => typeof(ITranslatable).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
            .ToList();

        foreach (var clr in types)
        {
            var sample = (ITranslatable)Activator.CreateInstance(clr, nonPublic: true)!;
            var eType = sample.GetEntityType();

            services.AddSingleton(new TranslationRegistration(
                eType,
                clr,
                typeof(TDbContext)
            ));
        }
        return services;
    }

    /// <summary>
    /// Registers the cross-module resolver once. Must be called after all AddTranslationRegistration* calls.
    /// </summary>
    public static IServiceCollection AddEntityTranslationResolver(
        this IServiceCollection services)
    {
        services.AddSingleton<IEntityTranslationResolver, EntityTranslationResolver>();
        return services;
    }
}