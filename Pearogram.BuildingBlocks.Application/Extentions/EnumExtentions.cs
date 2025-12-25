using Pearogram.BuildingBlocks.Application.Communications;
using Pearogram.BuildingBlocks.Domain.Validator;

namespace Pearogram.BuildingBlocks.Application.Extentions;

public static class EnumExtentions
{
    /// <summary>
    /// Tries to parse a string to the specified enum type in a safe and clean way.
    /// </summary>
    /// <typeparam name="TEnum">Enum type to parse into</typeparam>
    /// <param name="value">The string value to parse</param>
    /// <param name="ignoreCase">Ignore case when parsing (default: true)</param>
    /// <returns>A Result containing success status and parsed value if valid</returns>
    public static Result<TEnum?> ToEnum<TEnum>(this string value, bool ignoreCase = true) where TEnum : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<TEnum?>.Success(null);

        if (Enum.TryParse<TEnum>(value, ignoreCase, out var result))
            return Result<TEnum?>.Success(result);

        return Result<TEnum?>.Failure($"Invalid {typeof(TEnum).Name} value: '{value}'");
    }
    /// <summary>
    /// Converts an enum type to a list of dropdown items (Id + Name).
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <returns>A successful result containing the enum values as a list of <see cref="EnumResponseDto"/>.</returns>
    public static Result<List<EnumResponseDto>> ToDropDownList<TEnum>() where TEnum : struct, Enum
    {
        var values = Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Select(e => new EnumResponseDto
            {
                Id = Convert.ToInt32(e),
                Name = e.ToString()
            })
            .ToList();

        return Result<List<EnumResponseDto>>.Success(values);
    }
}
