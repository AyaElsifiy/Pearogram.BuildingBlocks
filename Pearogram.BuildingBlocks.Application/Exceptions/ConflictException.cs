namespace Pearogram.BuildingBlocks.Application.Exceptions;

public class ConflictException : ApplicationException
{
    public ConflictException(string message)
        : base(message, "CONFLICT")
    {
    }
}
