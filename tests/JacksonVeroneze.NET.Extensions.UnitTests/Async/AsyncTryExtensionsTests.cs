using JacksonVeroneze.NET.Extensions.Async;
using Xunit.Abstractions;

namespace JacksonVeroneze.NET.Extensions.UnitTests.Async;

public class AsyncTryExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AsyncTryExtensionsTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
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
}