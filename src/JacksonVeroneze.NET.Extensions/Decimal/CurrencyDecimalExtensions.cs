namespace JacksonVeroneze.NET.Extensions.Decimal;

public static partial class DecimalExtensions
{
    public static string ToCurrency(this decimal input)
        => ToFormat(input, "C2");

    public static string ToCurrency(this decimal? input)
        => input.ToFormat("C2");

    public static string ToAbsoluteCurrency(this decimal input)
        => ((decimal?)input).ToAbsoluteCurrency();

    public static string ToAbsoluteCurrency(this decimal? input)
        => input.ToAbsolute().ToCurrency();

    public static decimal? ToAbsoluteCurrency(
        this decimal? input, int decimals)
        => input?.ToRoundDefault(decimals) ?? input;
}
