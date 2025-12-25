namespace Pearogram.BuildingBlocks.Domain.Translation;
public class TranslationItemDto
{
    public TranslationItemDto()
    {
        FieldName = default!;
        Language = default!;
        Value = default!;
    }
    public string FieldName { get; set; }
    public string Language { get; set; }
    public string Value { get; set; }
}
