using System.Globalization;

namespace JacksonVeroneze.NET.Extensions.Decimal.FormatProvider;

public static class NumberProvider
{
    public static IFormatProvider Provider { get; }
        = Initialize();

    private static IFormatProvider Initialize()
    {
        NumberFormatInfo numberFormat = NumberFormatInfo.GetInstance(
            new CultureInfo("pt-BR"));

        numberFormat.CurrencyPositivePattern = 2;
        numberFormat.CurrencyNegativePattern = 12;

        return NumberFormatInfo.ReadOnly(numberFormat);
    }
}
