namespace Pearogram.BuildingBlocks.Application.Dtos.Users;

public abstract class AuditDto
{
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}

