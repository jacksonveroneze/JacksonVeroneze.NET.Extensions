using JacksonVeroneze.NET.Extensions.Async;
using Xunit.Abstractions;

namespace JacksonVeroneze.NET.Extensions.UnitTests.Async;

public class AsyncTimeoutExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AsyncTimeoutExtensionsTests(
        ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact(DisplayName = nameof(AsyncExtensions)
                        + nameof(AsyncExtensions.AwaitUntilTimeoutAsync)
                        + " : AwaitUntilTimeoutAsync - Success")]
    public async Task AwaitUntilTimeoutAsync_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        TimeSpan timeout = TimeSpan.FromMilliseconds(50);

        Task task = Task.Run(async () =>
        {
            _testOutputHelper.WriteLine("Start");

            await Task.Delay(200);

            _testOutputHelper.WriteLine("End");
        });

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        await task.AwaitUntilTimeoutAsync(timeout);

        await Task.Delay(300);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
    }
}
