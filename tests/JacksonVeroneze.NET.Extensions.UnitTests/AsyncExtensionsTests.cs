using JacksonVeroneze.NET.Extensions.Async;
using Xunit.Abstractions;

namespace JacksonVeroneze.NET.Extensions.UnitTests;

public class AsyncExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AsyncExtensionsTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    #region TryAsync

    [Fact(DisplayName = nameof(AsyncExtensions)
                        + nameof(AsyncExtensions.TryAsync)
                        + " : TryAsync - Success")]
    public async Task TryAsync_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        Task task = Task.Run(() =>
        {
            Task.Delay(100);
            _testOutputHelper.WriteLine($"Delay: {100}");
            throw new Exception("Test");
        });

        Action<Exception> handler = ex
            => Console.WriteLine(ex.Message);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        await task.TryAsync(handler);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
    }

    #endregion

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
                    Task.Delay(delay);
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
                        + " : WhenAllSequentialAsync - Success")]
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
                    Task.Delay(delay);
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