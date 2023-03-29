using JacksonVeroneze.NET.Extensions.Async;

namespace JacksonVeroneze.NET.Extensions.UnitTests;

public class AsyncExtensionsTests
{
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
            Console.WriteLine($"Delay: {100}");
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

    [Fact(DisplayName = nameof(AsyncExtensions)
                        + nameof(AsyncExtensions.WhenAllSequentialAsync)
                        + " : WhenAllSequentialAsync - Success")]
    public async Task WhenAllSequentialAsync_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        IEnumerable<Task> tasks = Enumerable.Range(1, 2)
            .Select(i =>
            {
                return Task.Run(() =>
                {
                    int delay = i * 100;
                    Task.Delay(delay);
                    Console.WriteLine($"Delay: {delay}");
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


    [Fact(DisplayName = nameof(AsyncExtensions)
                        + nameof(AsyncExtensions.WhenAllParallelAsync)
                        + " : WhenAllSequentialAsync - Success")]
    public async Task WhenAllParallelAsync_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        IEnumerable<Task> tasks = Enumerable.Range(1, 20)
            .Select(i =>
            {
                return Task.Run(() =>
                {
                    int delay = i * 100;
                    Task.Delay(delay);
                    Console.WriteLine($"Delay: {delay}");
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
}