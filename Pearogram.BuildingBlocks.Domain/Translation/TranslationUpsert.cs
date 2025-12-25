namespace Pearogram.BuildingBlocks.Domain.Translation;

public class TranslationUpsert
{
    public TranslationUpsert()
    {
        EntityType = default!;
        EntityType = default!;
        Values = default!;
        FieldName = default!;
    }

    public string EntityType { get; set; }
    public Guid EntityId { get; set; }
    public string FieldName { get; set; }
    public Dictionary<string,string> Values { get; set; }
}