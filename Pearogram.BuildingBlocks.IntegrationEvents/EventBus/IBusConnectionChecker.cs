namespace Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

public interface IBusConnectionChecker
{
    Task<bool> EnsureConnectedAsync(CancellationToken cancellationToken = default);
}
