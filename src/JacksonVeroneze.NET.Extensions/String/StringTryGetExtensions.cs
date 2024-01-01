using System.Globalization;

namespace JacksonVeroneze.NET.Extensions.String;

public static partial class StringExtensions
{
    public static int? TryGetIntValue(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null;
        }

        CultureInfo cultureInfo = CultureInfo.CurrentCulture;

        return int.TryParse(input, cultureInfo, out int value) ? value : null;
    }

    public static decimal? TryGetDecimalValue(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null;
        }

        CultureInfo cultureInfo = CultureInfo.CurrentCulture;

        return decimal.TryParse(input, cultureInfo, out decimal value) ? value : null;
    }

    public static DateOnly? TryGetDateOnlyValue(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null;
        }

        CultureInfo cultureInfo = CultureInfo.CurrentCulture;

        return DateOnly.TryParse(input, cultureInfo, out DateOnly value) ? value : null;
    }

    public static TimeOnly? TryGetTimeOnlyValue(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null;
        }

        CultureInfo cultureInfo = CultureInfo.CurrentCulture;

        return TimeOnly.TryParse(input, cultureInfo, out TimeOnly value) ? value : null;
    }
}
