using JacksonVeroneze.NET.Extensions.Async;
using Xunit.Abstractions;

namespace JacksonVeroneze.NET.Extensions.UnitTests.Async;

public class AsyncWhenAllExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AsyncWhenAllExtensionsTests(
        ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    #region WhenAllSequentialAsync

    [Fact(DisplayName = nameof(AsyncExtensions)
                        + nameof(AsyncExtensions.WhenAllSequentialAsync)
                        + " : WhenAllSequentialAsync - Success")]
    public async Task WhenAllSequentialAsync_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        IEnumerable<Task> tasks = Enumerable.Range(1, 2)
            .Select(item =>
            {
                return Task.Run(() =>
                {
                    int delay = item * 100;
                    _testOutputHelper.WriteLine($"Delay: {delay}");
                });
            });

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        await tasks.WhenAllSequentialAsync();

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
    }

    #endregion

    #region WhenAllParallelAsync

    [Fact(DisplayName = nameof(AsyncExtensions)
                        + nameof(AsyncExtensions.WhenAllParallelAsync)
                        + " : WhenAllParallelAsync - Success")]
    public async Task WhenAllParallelAsync_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        IEnumerable<Task> tasks = Enumerable.Range(1, 20)
            .Select(item =>
            {
                return Task.Run(() =>
                {
                    int delay = item * 100;
                    _testOutputHelper.WriteLine($"Delay: {delay}");
                });
            });

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        await tasks.WhenAllParallelAsync(5);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
    }

    #endregion
}
