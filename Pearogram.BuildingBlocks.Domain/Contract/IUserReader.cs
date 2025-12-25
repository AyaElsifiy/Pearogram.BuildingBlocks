using Pearogram.BuildingBlocks.Domain.Model;

namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface IUserReader
{
    Task<UserDto?> GetUserByEmailAsync(string email);
    Task<UserDto?> GetByIdAsync(Guid id);
    Task<bool> IsUserActive(Guid userId);
    Task<List<Guid>> GetAllUserIds();
    Task<bool> IsValidIdsAsync(IEnumerable<Guid> ids, bool forUsers = true);
    Task<List<UserDto>?> GetUsersAsync(IEnumerable<Guid> ids, CancellationToken ct = default);
    Task<string> GetUserNameAsync(Guid userId);
    string GetUserName(Guid userId);
    Task<Dictionary<Guid, string>> GetUserNamesAsync(IEnumerable<Guid> ids);

}
