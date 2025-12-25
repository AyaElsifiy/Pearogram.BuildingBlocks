namespace Pearogram.BuildingBlocks.Domain.ValueObjects;

public record Range<T> where T : IComparable<T>
{
    public T From { get; }
    public T To { get; }

    //I change here start --> from and end --> to
    private Range(T from, T to)
    {
        From = from;
        To = to;
    }
    // I commented constractor of EF beacuse this is not important here because this is a value object, not an entity,
    // but make sure that it will not cause problems.
    // This is not important here because this is a value object, not an entity,
    // but make sure that it will not cause problems.

    //private Range() { }

    public static Result<Range<T>> Create(T start, T end)
    {
        var guard = Guard.AgainstRangeValid(start, end, nameof(start), nameof(end));

        if (guard.IsFailure)
            return Result<Range<T>>.Failure(guard.Error);


        return Result<Range<T>>.Success(new Range<T>(start, end));
    }

    public bool Contains(T value) =>
        value.CompareTo(From) >= 0 && value.CompareTo(To) <= 0;

    public override string ToString() =>
        $"{From} - {To}";
}
