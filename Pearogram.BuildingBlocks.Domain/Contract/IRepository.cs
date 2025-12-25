using System.Linq.Expressions;

namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    T Update(T entity, bool isArchivingOperation = false);
    void Delete(Guid id);
    Task<T> GetByIdAsyncWithoutQueryFilter(Guid id);
    Task<IReadOnlyList<T>> GetAllWithIncludesAsReadOnlyAsync(params Expression<Func<T, object>>[] includes);
    Task<List<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
    Task<T?> GetByIdWithInludesAsync(Guid id, params Expression<Func<T, object>>[] includes);

    Task<T?> GetByIdWithIncludesAsync(Guid id,
    Func<IQueryable<T>, IQueryable<T>> includeFunc);
    Task<bool> HasRelatedDataAsync(Guid id);
    Task<bool> HasRelatedDataExcludingNavigationsAsync(Guid id, IEnumerable<string> excludedNavigations);
    IQueryable<T> GetAllWithoutQueryFilter();
    Task SoftDeleteAsync(Guid Id);
    IQueryable<T> GetAll();
    Task<IQueryable<T>> GetAll(bool withTranslations = true);
    T GetById(Guid id);
    Task<IReadOnlyList<T>> GetAllAsReadOnlyAsync();
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    Task<int> GetCountWithDeleteAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Guid> ids);
    Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Guid> ids, params Func<IQueryable<T>, IQueryable<T>>[] includes);
    void Delete(T entity);
    T GetByIdAsNoTracking(Guid id);

}

