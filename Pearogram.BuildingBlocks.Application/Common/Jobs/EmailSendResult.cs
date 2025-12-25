namespace Pearogram.BuildingBlocks.Application.Common.Jobs;

public class EmailSendResult
{
    public bool IsSuccess { get; }
    public string? ErrorMessage { get; }

    private EmailSendResult(bool isSuccess, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    public static EmailSendResult Success() => new(true);
    public static EmailSendResult Fail(string message) => new(false, message);
}
