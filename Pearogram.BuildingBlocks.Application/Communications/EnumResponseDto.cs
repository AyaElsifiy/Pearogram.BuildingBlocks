namespace Pearogram.BuildingBlocks.Application.Communications;

public class EnumResponseDto
{
    public EnumResponseDto()
    {
        Name = default!;
    }
    public int Id { get; set; }
    public string Name { get; set; }
}
