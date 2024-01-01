using JacksonVeroneze.NET.Extensions.Async;
using Xunit.Abstractions;

namespace JacksonVeroneze.NET.Extensions.UnitTests.Async;

public class AsyncFallbackExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AsyncFallbackExtensionsTests(
        ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact(DisplayName = nameof(AsyncExtensions)
                        + nameof(AsyncExtensions.FallbackAsync)
                        + " : FallbackAsync - Success")]
    public async Task FallbackAsync_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        int expected = 2;

        Task<int> task = Task.Run(() =>
        {
            _testOutputHelper.WriteLine($"Delay: {100}");

            if (true)
            {
                throw new Exception("Test");
            }

            return expected++;
        });

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        int result = await task.FallbackAsync(expected);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        result.Should()
            .Be(expected);
    }
}
