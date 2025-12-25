using Pearogram.BuildingBlocks.Domain.Exceptions;
using Pearogram.BuildingBlocks.Domain.Validator;

namespace Pearogram.BuildingBlocks.Domain.ValueObjects;

public record Email(string value)
{
    public static Result<Email> Create(string value)
    {
        var emailGuard = Guard.ValidEmail(value, nameof(value));
        if (emailGuard.IsFailure)
            throw new DomainException(emailGuard.Error);


        return Result<Email>.Success(new Email(value));
    }
    public override string ToString() => value;
}
