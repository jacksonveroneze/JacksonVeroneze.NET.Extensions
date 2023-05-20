using JacksonVeroneze.NET.Extensions.Async;
using Xunit.Abstractions;

namespace JacksonVeroneze.NET.Extensions.UnitTests.Async;

public class AsyncOnlyOneExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AsyncOnlyOneExtensionsTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact(DisplayName = nameof(AsyncExtensions)
                        + nameof(AsyncExtensions.OnlyOneAsync)
                        + " : OnlyOneAsync - Success")]
    public async Task OnlyOneAsync_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        IEnumerable<Func<CancellationToken, Task<int>>> tasks = Enumerable.Range(1, 3)
            .Select(item =>
            {
                Func<CancellationToken, Task<int>> func = async ct =>
                {
                    int delay = new Random().Next(100, 500);

                    _testOutputHelper.WriteLine($"Item: {item} - Delay: {delay}");

                    await Task.Delay(delay, ct);

                    return item;
                };

                return func;
            });

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        int result = await tasks.OnlyOneAsync();

        _testOutputHelper.WriteLine($"Result: {result}");

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        result.Should()
            .BeGreaterOrEqualTo(1);
    }
}