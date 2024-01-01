namespace JacksonVeroneze.NET.Extensions.DateAndTime;

public static class DateTimeExtensions
{
    public static DateTime ModifyTime(this DateTime input,
        int hours, int minutes, int seconds)
    {
        return new DateTime(input.Year, input.Month, input.Day,
            hours, minutes, seconds, DateTimeKind.Local);
    }

    public static DateTime ModifyTime(this DateTime input,
        TimeSpan timeSpan)
    {
        return new DateTime(input.Year, input.Month, input.Day,
            timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, DateTimeKind.Local);
    }

    public static DateTime ModifyTime(this DateTime input,
        DateTime time)
    {
        return new DateTime(input.Year, input.Month, input.Day,
            time.Hour, time.Minute, time.Second, DateTimeKind.Local);
    }

    public static DateTime ModifyTime(this DateTime input,
        TimeOnly time)
    {
        return new DateTime(input.Year, input.Month, input.Day,
            time.Hour, time.Minute, time.Second, DateTimeKind.Local);
    }
}
