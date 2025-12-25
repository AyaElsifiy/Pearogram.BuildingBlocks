namespace Pearogram.BuildingBlocks.Application.Exceptions;

public class ApplicationException : Exception
{
    public string Code { get; }
    public string? Details { get; }

    public ApplicationException(string message, string code = "APPLICATION_ERROR", string? details = null)
        : base(message)
    {
        Code = code;
        Details = details;
    }
}

