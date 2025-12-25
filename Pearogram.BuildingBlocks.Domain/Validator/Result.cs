using Pearogram.BuildingBlocks.Domain.Exceptions;

namespace Pearogram.BuildingBlocks.Domain.Validator;

public class Result<T>
{
    public bool IsSuccess { get; }
    public string Error { get; }
    public bool IsFailure => !IsSuccess;
    public T? Value { get; protected set; }
    public List<string> Errors { get;  set; } = new();

    protected Result()
    {
        IsSuccess = true;
    }
    protected Result(bool isSuccess, List<string> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors ?? new List<string>();
        Error = string.Join(", ", Errors);
    }

    protected Result(bool isSuccess, string error, T? value)
    {
        if (isSuccess && error != string.Empty)
            throw new InvalidOperationDomainException("Invalid success result");
        if (!isSuccess && error == string.Empty && value == null)
            throw new InvalidOperationDomainException("Invalid success result");

        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, string.Empty, value);
    }
    public static Result<T> Failure(string error)
    {
        return new Result<T>(false, error, default);
    }
    public static Result<T> Combine(params Result<T>[] results)
    {
        var isSuccess = true;
        List<string> errors = new List<string>();
        for (int i = 0; i < results?.Count(); i++)
        {
            if (!results[i].IsSuccess)
            {
                isSuccess = false;
                errors.Add(results[i].Error);
            }
        }

        return new Result<T>(isSuccess, errors);
    }
}

