using Pearogram.BuildingBlocks.Domain.Helpers;
using System.Text.RegularExpressions;

namespace Pearogram.BuildingBlocks.Domain.Validator;

public static class Guard
{
   private const string InternationalPhone = @"^\+[1-9]\d{7,14}$";
   private const int PhoneMaxLength = 14;

    /// <summary>
    /// Ensures the Egyptian NationalId yields a valid DateOfBirth (DateOnly).
    /// Returns Failure if:
    ///  - null/empty, wrong length, non-digits, bad century digit, impossible date, or future date.
    /// On success, sets the 'dob' out param and returns Success(true).
    /// </summary>
    public static Result<bool> AgainstInvalidNationalIdDob(string nationalId, out DateOnly dob, string? paramName = "nationalId")
    {
        dob = default;

        if (string.IsNullOrWhiteSpace(nationalId))
            return Result<bool>.Failure($"{paramName} is required.");

        var parsed = EgyptianNationalId.ExtractDateOfBirthOrThrow(nationalId);


        dob = parsed;
        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstNullOrEmpty(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            return Result<bool>.Failure($"{paramName} Value cannot be null, empty, or whitespace.");

        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstNullOrDefault<T>(T value, string paramName)
    {
        if (value == null || EqualityComparer<T>.Default.Equals(value, default))
            return Result<bool>.Failure($"{paramName} value cannot be null or default.");

        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstNullOrEmpty<T>(IEnumerable<T> value, string paramName)
    {
        if (value == null || !value.Any())
            return Result<bool>.Failure($"Collection cannot be null or empty.");

        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstZeroOrNegative<T>(T value, string paramName) where T : struct, IComparable<T>
    {
        if (value.CompareTo(default(T)) <= 0)
            return Result<bool>.Failure($"Value must be greater than zero. Actual value: {value}");

        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstGuidDefaultValue(Guid value, string paramName)
    {
        if (value == default)
            return Result<bool>.Failure($"Value must be valid Guid");
        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstDefaultEnumValue<T>(T value, string paramName) where T : struct, Enum
    {
        if (value.Equals(default(T)))
            return Result<bool>.Failure($"Value cannot be default({paramName}).");
        return Result<bool>.Success(true);
    }
    public static Result<bool> ValidateNoChanges<T>(T currentState, T newState)
    {
        string errorMessage = "The provided values are identical. No update needed.";
        if (EqualityComparer<T>.Default.Equals(currentState, newState))
            return Result<bool>.Failure(errorMessage);
        return Result<bool>.Success(true);
    }
    public static Result<bool> ValidEmail(string email, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Result<bool>.Failure($"{propertyName} is required.");
        if (!IsValidEmail(email))
            return Result<bool>.Failure($"Invalid email format for {propertyName}.");
        return Result<bool>.Success(true);
    }
    public static Result<bool> ValidLink(string link, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(link))
            return Result<bool>.Failure($"{propertyName} is required.");
        if (!IsValidLink(link))
            return Result<bool>.Failure($"Invalid link format for {propertyName}.");
        return Result<bool>.Success(true);
    }
    private static bool IsValidLink(string link)
    {
        var pattern = @"^(https?://)" + @"([\w\-]+\.)+[\w\-]+" + @"([/?#].*)?$";
        return Regex.IsMatch(link, pattern, RegexOptions.IgnoreCase);
    }
    public static Result<bool> ValidatePhone(string phone, string propertyName)
    {
        if (phone == string.Empty)
            return Result<bool>.Success(true);

        var maxLengthResult = HasMaxLength(phone, PhoneMaxLength);

        if (maxLengthResult.IsFailure)
            return Result<bool>.Failure(maxLengthResult.Error);

        if (!IsValidPhone(phone))
            return Result<bool>.Failure($"Invalid phone number format for {propertyName}.");

        return Result<bool>.Success(true);
    }
    private static bool IsValidPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;
        string pattern = InternationalPhone;
        return Regex.IsMatch(phone, pattern);
    }
    public static Result<bool> HasMaxLength(string? value, int maxLength)
    {
        if (value?.Length > maxLength)
            return Result<bool>.Failure($"Value cannot be longer than {maxLength} characters");

        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstNull<T>(T? value, string parameterName) where T : class
    {
        if (value == null)
            return Result<bool>.Failure($"Parameter '{parameterName}' cannot be null.");

        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstTrue(bool condition, string message)
    {
        if (condition)
            return Result<bool>.Failure(message);

        return Result<bool>.Success(true);
    }
    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    }
    public static Result<bool> AgainstDateInFuture(DateTime? value, string paramName)
    {
        if (value.HasValue && value.Value > DateTime.UtcNow)
            return Result<bool>.Failure($"{paramName} cannot be in the future.");
        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstDateInFuture(DateOnly value, string paramName)
    {
        var now = DateOnly.FromDateTime(DateTime.UtcNow);
        if (value > now)
            return Result<bool>.Failure($"{paramName} cannot be in the future.");
        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstStartDateAfterEndDate(DateTime? startDate, DateTime? endDate, string startParamName, string endParamName)
    {
        if (startDate.HasValue && endDate.HasValue && startDate.Value > endDate.Value)
            return Result<bool>.Failure($"{startParamName} must be before {endParamName}.");
        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstStartDateAfterEndDate(TimeOnly? startDate, TimeOnly? endDate, string startParamName, string endParamName)
    {
        if (startDate.HasValue && endDate.HasValue && startDate.Value > endDate.Value)
            return Result<bool>.Failure($"{startParamName} must be before {endParamName}.");
        return Result<bool>.Success(true);
    }

    public static Result<bool> AgainstRangeValid<T>(T start, T end, string startParamName, string endParamName) where T : IComparable<T>
    {
        if (start.CompareTo(end) > 0)
        {
            return Result<bool>.Failure(
                $"{startParamName} must be before {endParamName}."
            );
        }

        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstPastDate(DateTimeOffset? date, string paramName)
    {
        if (date.HasValue && date.Value <= DateTimeOffset.UtcNow)
            return Result<bool>.Failure($"{paramName} must be a future date.");

        return Result<bool>.Success(true);
    }
    public static Result<bool> AgainstPastDate(DateOnly? date, string paramName)
    {
        if (date.HasValue && date.Value <= DateOnly.FromDateTime(DateTime.UtcNow))
            return Result<bool>.Failure($"{paramName} must be a future date.");

        return Result<bool>.Success(true);
    }
}
