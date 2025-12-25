using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.Domain.Model;

public class UserDto
{
    public UserDto()
    {
        Name = string.Empty;
        Email = string.Empty;
        PasswordHash = string.Empty;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }
    public string Role { get; set; }
    public Guid RoleId { get; set; }
    public int UserType { get; set; }
    public EPredefinedRolesEnum PredefinedRole { get; set; }
}
