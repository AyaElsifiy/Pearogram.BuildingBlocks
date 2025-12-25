using System.Collections.Concurrent;
using System.Reflection;

namespace Pearogram.BuildingBlocks.Domain.Attributes;

public  class TranslationReflectionCache
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _cache = new();

    public static PropertyInfo[] GetTranslatableProps(Type t)
        => _cache.GetOrAdd(t, type =>
            type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(string)
                         && Attribute.IsDefined(p, typeof(TranslatableAttribute)))
                .ToArray());
}
