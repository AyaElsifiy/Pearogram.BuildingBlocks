using MassTransit;
using System.Text.RegularExpressions;

namespace Pearogram.BuildingBlocks.IntegrationEvents.EventBus;

public class CustomEntityNameFormatter
{
    public string FormatEntityName<T>()
    {
        var name = typeof(T).Name;
        var formatted = Regex.Replace(name, "([a-z])([A-Z])", "$1-$2").ToLower();
        return formatted;
    }
}
