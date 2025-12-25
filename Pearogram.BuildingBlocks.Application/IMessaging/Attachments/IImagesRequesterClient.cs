using Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Attachments;
using Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.EducationsCore;
using Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;

namespace Pearogram.BuildingBlocks.Application.IMessaging.Attachments;

public interface IImagesRequesterClient
{
    //Task<SaveEntityImageResponseEvent> SaveImageAsync(SaveEntityImageRequestEvent request);
    Task<DeleteAllEntityFilesResponseEvent> DeleteFilesAsync(DeleteAllEntityFilesRequestEvent request);
    Task<DeleteMaterialResponseEvent> DeleteMaterialAsync(DeleteMaterialRequestEvent request);
    Task<MaterialsInfoResponse> GetMaterialInfo(MaterialsInfoRequest request);
    Task<string?> GetMaterialPath(Guid documentId);

}
