namespace Pearogram.BuildingBlocks.Application.Helpers;

public static class DateTimeHelper
{
    public static DateTimeOffset ToUtcOffset(this DateTime dateTime)
    {
        return new DateTimeOffset(DateTime.SpecifyKind(dateTime, DateTimeKind.Utc));
    }

    public static DateTimeOffset ToLocalOffset(this DateTime dateTime)
    {
        var localOffset = TimeZoneInfo.Local.GetUtcOffset(dateTime);
        return new DateTimeOffset(DateTime.SpecifyKind(dateTime, DateTimeKind.Local), localOffset);
    }
}
