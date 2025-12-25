namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    //IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
}