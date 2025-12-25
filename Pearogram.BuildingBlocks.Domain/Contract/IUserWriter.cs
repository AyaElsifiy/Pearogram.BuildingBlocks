namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface IUserWriter
{
    Task<bool> UpdateLastLoginDate(Guid userId);
    Task<bool> UpdatePassword(Guid userId, string hashedPassword);
    Task<bool> ActivateUser(Guid userId);
    Task<bool> VerifyUser(Guid userId);
}
