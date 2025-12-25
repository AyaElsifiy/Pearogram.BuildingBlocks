namespace Pearogram.BuildingBlocks.Domain.ValueObjects;

public record Phone(string value)
{
    public static Result<Phone> Create(string value)
    {
        var phoneGuard = Guard.ValidatePhone(value, nameof(value));

        if (phoneGuard.IsFailure)
            return Result<Phone>.Failure(phoneGuard.Error);

        return Result<Phone>.Success(new Phone(value));
    }
    public override string ToString() => value;
}
