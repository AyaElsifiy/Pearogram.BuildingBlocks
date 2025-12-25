using Microsoft.EntityFrameworkCore;
using Pearogram.BuildingBlocks.Domain.Model;
using System.Linq.Expressions;

namespace Pearogram.BuildingBlocks.Persistence.Extentions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplySoftDeleteFilter(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var body = Expression.Equal(
                        Expression.Property(parameter, nameof(IEntity.IsDeleted)),
                        Expression.Constant(false)
                    );

                    var lambda = Expression.Lambda(body, parameter);

                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(lambda);
                }
            }
        }
    }

}
