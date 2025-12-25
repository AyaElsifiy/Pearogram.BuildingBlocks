namespace Pearogram.BuildingBlocks.Application.Communications;

public class DropDownListResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DropDownListResponse()
    {
        Name = string.Empty;
    }
}
