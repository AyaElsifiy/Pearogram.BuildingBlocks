using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Pearogram.BuildingBlocks.Application.Helpers;

public class EntityLogger : IEntityLogger
{
    private readonly ILogger<EntityLogger> _logger;

    public EntityLogger(ILogger<EntityLogger> logger)
    {
        _logger = logger;
    }

    public void LogCreate<TEntity>(TEntity entity, string userName, Guid userId) where TEntity : class
    {
        _logger.LogInformation(
            "Action : POST performend on Entity : {EntityName} with Id : {EntityId}. AdditionalData : {AdditionalData}",
            typeof(TEntity).Name,
            GetEntityId(entity),
            $"The {typeof(TEntity).Name} Added successfully By: {userName} with Id {userId}"
        );
    }
    public void LogDelete<TEntity>(TEntity entity, string userName, Guid userId) where TEntity : class
    {
        _logger.LogInformation(
            "Action : DELETE performed on Entity : {EntityName} with Id : {EntityId}. AdditionalData : {AdditionalData}",
            typeof(TEntity).Name,
            GetEntityId(entity),
            $"The {typeof(TEntity).Name} Deleted successfully by {userName} with Id {userId}"
        );
    }
    public void LogError<TEntity>(TEntity entity, Exception ex) where TEntity : class
    {
        var entityName = typeof(TEntity).Name;
        var entityId = GetEntityId(entity);

        _logger.LogError(
            ex,
            " ERROR: Failed Occur In Entity : {EntityName} with Id : {EntityId}  Message: {ErrorMessage}",
            entityName,
            entityId,
            ex.Message
        );
    }


    public void LogUpdate<TEntity>(
    TEntity entity,
    string userName,
    Guid userId,
    EntityEntry<TEntity> entry,
    PropertyValues originalValues) where TEntity : class
    {
        var changes = new List<string>();
        var originals = originalValues ?? entry.OriginalValues;

        foreach (var property in entry.Metadata.GetProperties())
        {
          
            if (property.PropertyInfo?.DeclaringType != typeof(TEntity))
                    continue;
                var original = originals[property];
            var current = entry.CurrentValues[property];

                changes.Add($"{property.Name}: From '{original}' To '{current}'");
        }

        _logger.LogInformation(
            "Action : PUT performed on Entity : {EntityName} with Id : {EntityId} updated by {UserName} ({UserId}). Changes: {Changes}",
            typeof(TEntity).Name,
            GetEntityId(entity),
            userName,
            userId,
            string.Join(", ", changes)
        );
    }

    public void LogUpdate<TEntity>(
        TEntity entity,
        string userName,
        Guid userId,
        string propertyName,
        object newValue) where TEntity : class
    {
            _logger.LogInformation(
            "Action: PUT performed on Entity: {EntityName} with Id: {EntityId}. " +
            "Updated {PropertyValues} to {NewValue} by {UserName} ({UserId})",
            typeof(TEntity).Name,
            GetEntityId(entity),
            propertyName,
            newValue == null ?"" : newValue?.ToString() ?? "null",
            userName,
            userId);
    }
    private object? GetEntityId<TEntity>(TEntity entity)
    {
        var prop = entity!.GetType().GetProperty("Id");
        return prop?.GetValue(entity, null);
    }
}
