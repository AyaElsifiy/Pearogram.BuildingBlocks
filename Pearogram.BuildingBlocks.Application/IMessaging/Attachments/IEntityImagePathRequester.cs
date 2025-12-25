using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.Application.IMessaging.Attachments;

public interface IEntityImagePathRequester
{
    Task<string> RequestEntityImagePathAsync(Guid entityId, EEntityType entityType);
    Task<Tuple<string, string>> RequestEntityImageNameAndPathAsync(Guid entityId, EEntityType entityType);
}
