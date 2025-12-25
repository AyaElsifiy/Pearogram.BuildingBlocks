namespace Pearogram.BuildingBlocks.Application.Common.Validation;
public static class ValidationMessages
{
    public const string PhoneFormat = "Use international format (E.164), e.g., +201001234567.";
    public const string EmailFormat = "Invalid email address format.";
    public const string PasswordStrength = "Password must contain at least 8 characters, one letter, and one number.";
    public const string NameFormat = "Name must contain only letters and spaces (2-50 chars).";
}