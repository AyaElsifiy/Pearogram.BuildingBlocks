namespace Pearogram.BuildingBlocks.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string entity, object key)
        : base($"{entity} with key '{key}' was not found.", "NOT_FOUND")
    {
    }
    public NotFoundException(string message)
    : base(message)
    {
    }
}
