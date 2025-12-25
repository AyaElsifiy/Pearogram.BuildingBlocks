namespace Pearogram.BuildingBlocks.Domain.Exceptions;

public class InvalidValueException : Exception
{
    public InvalidValueException(string message) : base(message)
    { }
    public InvalidValueException(string message, string? paramName) : base(message)
    { }
}

