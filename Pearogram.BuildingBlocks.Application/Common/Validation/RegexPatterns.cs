namespace Pearogram.BuildingBlocks.Application.Common.Validation;

public static class RegexPatterns
{
    public const string PhoneE164 = @"^\+[1-9]\d{7,14}$";
    public const string Email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    public const string Password = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$";
    public const string Name = @"^[A-Za-z\s]{2,50}$";
}
