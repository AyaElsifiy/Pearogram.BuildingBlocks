
using System.Linq.Expressions;

namespace Pearogram.BuildingBlocks.Application.Extentions;

public static class LinqExtentions
{
  
    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> source,
        bool condition,
        Expression<Func<T, bool>> predicate)
    {
        if (condition)
        {
            return source.Where(predicate);
        }

        return source;
    }
    public static IEnumerable<T> WhereIf<T>(
            this IEnumerable<T> source,
            bool condition,
            Func<T, bool> predicate)
    {
        if (condition)
        {
            return source.Where(predicate);
        }

        return source;
    }

    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize = 5)
    {
        if (pageSize <= 0) 
            pageSize = 5;

        int skip = pageNumber * pageSize;

        return query
            .Skip(skip)
            .Take(pageSize);
    }

    // For List<T>
    public static List<T> Paginate<T>(this List<T> list, int pageNumber, int pageSize = 5)
    {
        if (pageSize <= 0) pageSize = 5;
        int skip = pageNumber * pageSize;

        return list.Skip(skip).Take(pageSize).ToList();
    }
    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> list, int pageNumber, int pageSize = 5)
    {
        if (pageSize <= 0) pageSize = 5;
        int skip = pageNumber * pageSize;

        return list.Skip(skip).Take(pageSize).ToList();
    }
    public static IQueryable<T> WhereIfNotNull<T, TVal>(
       this IQueryable<T> source,
       TVal? value,
       Func<TVal, Expression<Func<T, bool>>> predicateFactory)
       where TVal : struct
       => value.HasValue ? source.Where(predicateFactory(value.Value)) : source;

    public static IQueryable<T> WhereIfNotNullOrWhiteSpace<T>(
     this IQueryable<T> source,
     string? value,
     Func<string, Expression<Func<T, bool>>> predicateFactory)
     => !string.IsNullOrWhiteSpace(value)
         ? source.Where(predicateFactory(value.Trim()))
         : source;
}
