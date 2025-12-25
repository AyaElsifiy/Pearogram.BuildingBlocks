namespace Pearogram.BuildingBlocks.Application.Communications;

public class EnumDropDownListResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EnumDropDownListResponse()
    {
        Name = string.Empty;
    }
}