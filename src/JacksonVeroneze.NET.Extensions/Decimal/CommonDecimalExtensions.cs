using JacksonVeroneze.NET.Extensions.Decimal.FormatProvider;

namespace JacksonVeroneze.NET.Extensions.Decimal;

public static partial class DecimalExtensions
{
    private const string DefaultSymbolNullValue = "";

    public static string ToFormat(this decimal? input, string format)
    {
        return input.HasValue
            ? input.Value.ToString(format, NumberProvider.Provider)
            : DefaultSymbolNullValue;
    }

    public static decimal ToRoundDefault(this decimal input, int decimals)
        => Math.Round(input, decimals);

    public static decimal? ToRoundDefault(this decimal? input, int decimals)
        => input?.ToRoundDefault(decimals) ?? input;

    public static decimal ToAbsolute(this decimal input)
        => Math.Abs(input);

    public static decimal? ToAbsolute(this decimal? input)
        => input?.ToAbsolute() ?? input;
}
