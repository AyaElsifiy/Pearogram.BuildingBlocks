using MassTransit;
using MediatR;
using Pearogram.BuildingBlocks.Application.IMessaging.Attachments;
using Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Settings;
using Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.TaskManagement;

namespace Pearogram.BuildingBlocks.Application.Features.RecentlyDeleted;

public class DeleteEntityAttachmentsHandler : INotificationHandler<DeleteEntityAttachments>
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IImagesRequesterClient _imagesRequesterClient;

    public DeleteEntityAttachmentsHandler(
        IPublishEndpoint publishEndpoint,
        IImagesRequesterClient imagesRequesterClient)
    {
        _publishEndpoint = publishEndpoint;
        _imagesRequesterClient = imagesRequesterClient;
    }
    public Task Handle(DeleteEntityAttachments notification, CancellationToken cancellationToken)
    {
        var request = new DeleteAllEntityFilesRequestEvent
        {
            Id = notification.Id,
            EntityType = notification.EntityType.ToString()
        };

        return _publishEndpoint.Publish(request, cancellationToken);
    }
}
