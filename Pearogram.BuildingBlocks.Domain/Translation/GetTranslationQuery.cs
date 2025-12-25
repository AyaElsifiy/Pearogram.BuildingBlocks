namespace Pearogram.BuildingBlocks.Domain.Translation;

public class GetTranslationQuery
{
    public GetTranslationQuery()
    {
        EntityType = default!;
    }
    
    public string EntityType { get; set; }
    public Guid EntityId { get; set; }
}