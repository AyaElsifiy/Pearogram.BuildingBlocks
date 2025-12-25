namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface IUserInfo
{
    Guid UserId { get; set; }
    string? UserName { get; set; }
}
