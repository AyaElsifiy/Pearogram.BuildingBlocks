namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.EducationsCore;

public class GetMaterialPathResponse
{
    public string FilePath { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
}
