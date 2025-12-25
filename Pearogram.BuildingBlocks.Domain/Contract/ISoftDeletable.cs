namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface ISoftDeletable
{
    public bool IsDeleted { get; set; }
}
