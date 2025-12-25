namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface ICurrentUserService
{
    Guid? UserId { get; }
}
