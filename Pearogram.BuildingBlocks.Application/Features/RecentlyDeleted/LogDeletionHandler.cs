using MassTransit;
using MediatR;
using Pearogram.BuildingBlocks.Domain.Events;
using Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Settings;

namespace Pearogram.BuildingBlocks.Application.Features.RecentlyDeleted;
public class LogDeletionHandler : INotificationHandler<EntityLogDeletionDomainEvent>
{

    private readonly IPublishEndpoint _publishEndpoint;

    public LogDeletionHandler(
        IPublishEndpoint publishEndpoint)
    {

        _publishEndpoint = publishEndpoint;
    }

    public async Task Handle(EntityLogDeletionDomainEvent log, CancellationToken cancellationToken)
    {
        var request = new EntityLogDeletion(
                  log.Id,
                  log.EntityType,
                  log.ModuleType,
                  log.Name,
                  log.deletedBy,
                  log.deletedAt);

        await _publishEndpoint.Publish(request, cancellationToken);
    }
}