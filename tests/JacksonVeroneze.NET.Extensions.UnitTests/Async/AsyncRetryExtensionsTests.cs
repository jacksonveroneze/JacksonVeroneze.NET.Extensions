using JacksonVeroneze.NET.Extensions.Async;
using Xunit.Abstractions;

namespace JacksonVeroneze.NET.Extensions.UnitTests.Async;

public class AsyncRetryExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AsyncRetryExtensionsTests(
        ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact(DisplayName = nameof(AsyncExtensions)
                        + nameof(AsyncExtensions.RetryAsync)
                        + " : RetryAsync - Success")]
    public void RetryAsync_Success()
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
