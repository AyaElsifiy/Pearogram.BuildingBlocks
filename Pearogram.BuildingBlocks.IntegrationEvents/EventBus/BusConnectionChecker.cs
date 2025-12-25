using MassTransit;
using Microsoft.Extensions.Logging;

namespace Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

public class BusConnectionChecker : IBusConnectionChecker
{
    private readonly IBusControl _busControl;
    private readonly ILogger<BusConnectionChecker> _logger;

    public BusConnectionChecker(IBusControl busControl, ILogger<BusConnectionChecker> logger)
    {
        _busControl = busControl;
        _logger = logger;
    }

    public async Task<bool> EnsureConnectedAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var busHealth =  _busControl.CheckHealth();
            if (busHealth.Status == BusHealthStatus.Healthy)
            {
                _logger.LogInformation("Bus is healthy and connected.");
                return true;
            }

            _logger.LogWarning("Bus is not healthy (Status: {Status}). Attempting to start/reconnect...", busHealth.Status);
            await _busControl.StartAsync(cancellationToken);
            busHealth = _busControl.CheckHealth();

            if (busHealth.Status == BusHealthStatus.Healthy)
            {
                _logger.LogInformation("Bus successfully reconnected.");
                return true;
            }

            _logger.LogError("Bus health check failed after reconnect attempt. Status: {Status}", busHealth.Status);
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to ensure bus connection.");
            return false;
        }
    }
}
