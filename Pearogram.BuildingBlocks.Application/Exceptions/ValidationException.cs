namespace Pearogram.BuildingBlocks.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public  string[]  Errors { get; private set; }
    public ValidationException(params string[] errors):base(errors.FirstOrDefault())
    {   
        Errors = errors;
    }
}