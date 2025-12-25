using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.EducationsCore;

public class MaterialsInfoResponse
{
    public MaterialsInfoResponse()
    {
        FileName = string.Empty;
        Description = string.Empty;
        Message = string.Empty;
        FileExtension = string.Empty;
    }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string FileName { get; set; }
    public string Description { get; set; }
    public string FileExtension { get; set; }
    public EFileType FileType { get; set; }
    public Guid FileExtensionId { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
}
