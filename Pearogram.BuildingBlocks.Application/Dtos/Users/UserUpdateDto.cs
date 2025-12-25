namespace Pearogram.BuildingBlocks.Application.Dtos.Users;

public class UserUpdateDto
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public Guid RoleId { get; set; }
    public Guid CompanyId { get; set; }
    public string? Description { get; set; }
    public string? FileName { get; set; }
    public string? ImageBase64 { get; set; }
    public Guid UpdatedBy { get; set; }
}
