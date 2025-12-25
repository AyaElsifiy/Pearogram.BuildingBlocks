using Microsoft.Extensions.Logging;
using Serilog;

namespace Pearogram.BuildingBlocks.Application.Helpers;

public class LogHelper
{
    public static void LogEntityAction(LoggingDto dto, LogLevel logLevel = LogLevel.Information)
    {
        string Message = $"Action {dto.actionType} performed on {dto.entityName} with ID {dto.entityId} , additionalData {dto.additionalData}";

        switch (logLevel)
        {
            case LogLevel.Information:
                Log.Information(Message);
                break;

            case LogLevel.Warning:
                Log.Warning(Message);
                break;

            case LogLevel.Error:
                Log.Error(Message);
                break;

            default:
                Log.Information(Message);
                break;
        }
    }
}