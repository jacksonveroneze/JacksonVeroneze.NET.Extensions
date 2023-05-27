using JacksonVeroneze.NET.Extensions.Predicate;
using Xunit.Abstractions;

namespace JacksonVeroneze.NET.Extensions.UnitTests.Predicate;

public class PredicateExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public PredicateExtensionsTests(
        ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact(DisplayName = nameof(PredicateExtensions)
                        + nameof(PredicateExtensions.And)
                        + " : And - Success")]
    public void And_Success()
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

    [Fact(DisplayName = nameof(PredicateExtensions)
                        + nameof(PredicateExtensions.Or)
                        + " : Or - Success")]
    public void Or_Success()
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