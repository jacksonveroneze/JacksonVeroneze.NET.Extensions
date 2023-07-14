using JacksonVeroneze.NET.Extensions.Decimal;
using Xunit.Abstractions;

namespace JacksonVeroneze.NET.Extensions.UnitTests.Decimal;

public class DecimalExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public DecimalExtensionsTests(
        ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory(DisplayName = nameof(DecimalExtensions)
                          + nameof(DecimalExtensions.ToCurrency)
                          + " : ToCurrency - Success")]
    [InlineData(1, "R$ 1,00")]
    [InlineData(1.1, "R$ 1,10")]
    [InlineData(1.123456, "R$ 1,12")]
    [InlineData(12.123456, "R$ 12,12")]
    [InlineData(123.123456, "R$ 123,12")]
    [InlineData(1234.123456, "R$ 1.234,12")]
    [InlineData(12345.123456, "R$ 12.345,12")]
    [InlineData(123456.123456, "R$ 123.456,12")]
    [InlineData(1234567.123456, "R$ 1.234.567,12")]
    [InlineData(-1234567.123456, "R$ -1.234.567,12")]
    [InlineData(-123456.123456, "R$ -123.456,12")]
    [InlineData(-12345.123456, "R$ -12.345,12")]
    [InlineData(-1234.123456, "R$ -1.234,12")]
    [InlineData(-123.123456, "R$ -123,12")]
    [InlineData(-12.123456, "R$ -12,12")]
    [InlineData(-1.123456, "R$ -1,12")]
    [InlineData(-1.1, "R$ -1,10")]
    [InlineData(-1, "R$ -1,00")]
    public void ToCurrency_Success(decimal input, string expected)
    {
        // -------------------------------------------------------
        // Arrange && Act
        // -------------------------------------------------------
        string result = input.ToCurrency();

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        result.Should()
            .NotBeNullOrEmpty()
            .And.BeEquivalentTo(expected);
    }
}
