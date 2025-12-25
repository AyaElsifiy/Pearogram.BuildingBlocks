namespace Pearogram.BuildingBlocks.Domain.Model;

public class BaseSeedEntity : Entity, IEntity
{
    public new Guid? CreatedBy { get; set; }


}
