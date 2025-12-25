namespace Pearogram.BuildingBlocks.Domain.Exceptions;

public class InvalidUrlException : Exception
{
    public InvalidUrlException(string message, string? paramName) : base(message)
    { }
}
