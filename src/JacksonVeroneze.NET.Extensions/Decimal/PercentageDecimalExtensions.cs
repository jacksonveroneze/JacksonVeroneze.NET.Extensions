namespace JacksonVeroneze.NET.Extensions.Decimal;

public static partial class DecimalExtensions
{
    public static string ToPercentage(this decimal? input)
    {
        return input.ToFormat("P2");
    }

    public static string ToAbsolutePercentage(this decimal? input)
    {
        return input.ToAbsolute().ToPercentage();
    }
}
