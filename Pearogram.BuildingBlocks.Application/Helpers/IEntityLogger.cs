using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Pearogram.BuildingBlocks.Application.Helpers;

public interface IEntityLogger
{
    void LogCreate<TEntity>(TEntity entity, string userName, Guid userId)
        where TEntity : class;

    //void LogUpdate<TEntity>(TEntity entity, string userName, Guid userId, EntityEntry<TEntity> entry)
    //    where TEntity : class;

    void LogDelete<TEntity>(TEntity entity, string userName, Guid userId)
        where TEntity : class;
    public void LogError<TEntity>(TEntity entity, Exception ex) where TEntity : class;
    public void LogUpdate<TEntity>(
    TEntity entity,
    string userName,
    Guid userId,
    EntityEntry<TEntity> entry,
    PropertyValues originalValues) where TEntity : class;

    public void LogUpdate<TEntity>(
       TEntity entity,
       string userName,
       Guid userId,
       string propertyName,
       object newValue) where TEntity : class;
}

