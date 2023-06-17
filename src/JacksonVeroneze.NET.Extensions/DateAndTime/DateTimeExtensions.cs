namespace JacksonVeroneze.NET.Extensions.DateAndTime;

public static class DateTimeExtensions
{
    public static DateTime ModifyTime(this DateTime input,
        int hours, int minutes, int seconds)
    {
        return new(input.Year, input.Month, input.Day,
            hours, minutes, seconds);
    }

    public static DateTime ModifyTime(this DateTime input,
        TimeSpan timeSpan)
    {
        return new(input.Year, input.Month, input.Day,
            timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    }
}
