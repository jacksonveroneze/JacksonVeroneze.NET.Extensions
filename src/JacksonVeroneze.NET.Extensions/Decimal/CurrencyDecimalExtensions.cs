namespace JacksonVeroneze.NET.Extensions.Decimal;

public static partial class DecimalExtensions
{
    public static string ToCurrency(this decimal input)
    {
        return ToFormat(input, "C2");
    }

    public static string ToCurrency(this decimal? input)
    {
        return input.ToFormat("C2");
    }

    public static string ToAbsoluteCurrency(this decimal input)
    {
        return ((decimal?)input).ToAbsoluteCurrency();
    }

    public static string ToAbsoluteCurrency(this decimal? input)
    {
        return input.ToAbsolute().ToCurrency();
    }

    public static decimal? ToAbsoluteCurrency(
        this decimal? input, int decimals)
    {
        return input?.ToRoundDefault(decimals) ?? input;
    }
}
