namespace Pearogram.BuildingBlocks.Application.Dtos.Users;

public class UserCompanyResult
{
    public Guid? CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string Message { get; set; } = string.Empty;
}
