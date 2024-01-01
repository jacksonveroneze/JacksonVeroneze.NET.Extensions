using JacksonVeroneze.NET.Extensions.String;
using Xunit.Abstractions;

namespace JacksonVeroneze.NET.Extensions.UnitTests.String;

public class StringExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public StringExtensionsTests(
        ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact(DisplayName = nameof(StringExtensions)
                        + nameof(StringExtensions.ToUpperFirstCharacter)
                        + " : ToUpperFirstCharacter - Success")]
    public void ToUpperFirstCharacter_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
    }
}
