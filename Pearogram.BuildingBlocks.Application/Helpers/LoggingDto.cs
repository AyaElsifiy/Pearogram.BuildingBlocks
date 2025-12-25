using System.Text;

namespace Pearogram.BuildingBlocks.Application.Helpers;

public class LoggingDto
{
    public string actionType { get; set; }
    public string entityName { get; set; }
    public Guid entityId { get; set; }
    public StringBuilder? additionalData { get; set; }
    public LoggingDto()
    {
        actionType = string.Empty;
        entityName = string.Empty;
    }
}
