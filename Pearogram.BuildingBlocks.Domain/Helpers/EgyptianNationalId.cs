namespace Pearogram.BuildingBlocks.Domain.Helpers;

public static class EgyptianNationalId
{
    public static DateOnly ExtractDateOfBirthOrThrow(string nationalId)
    {
        if (string.IsNullOrWhiteSpace(nationalId) || nationalId.Length != 14)
            throw new ArgumentException("NationalId must be 14 digits.", nameof(nationalId));

        for (int i = 0; i < nationalId.Length; i++)
            if (nationalId[i] < '0' || nationalId[i] > '9')
                throw new ArgumentException("NationalId must contain only digits.", nameof(nationalId));

        int centuryBase = nationalId[0] switch
        {
            '2' => 1900,
            '3' => 2000,
            _ => throw new ArgumentException("NationalId has invalid century digit.", nameof(nationalId))
        };

        int yy = int.Parse(nationalId.AsSpan(1, 2));
        int mm = int.Parse(nationalId.AsSpan(3, 2));
        int dd = int.Parse(nationalId.AsSpan(5, 2));

        int year = centuryBase + yy;

        if (!DateOnly.TryParse($"{year:D4}-{mm:D2}-{dd:D2}", out var dob))
            throw new ArgumentException("NationalId contains an impossible date.", nameof(nationalId));

        if (dob > DateOnly.FromDateTime(DateTime.UtcNow))
            throw new ArgumentException("NationalId date of birth cannot be in the future.", nameof(nationalId));

        return dob;
    }

}
