namespace Pearogram.BuildingBlocks.Domain.Translation;

public class TranslationRowDto
{
    public TranslationRowDto()
    {
        FieldName = default!;
        Default = default!;
        Languages = default!;
    }
    public string FieldName { get; set; }              
    public string Default { get; set; }          
    public Dictionary<string, string> Languages { get; set; }
}