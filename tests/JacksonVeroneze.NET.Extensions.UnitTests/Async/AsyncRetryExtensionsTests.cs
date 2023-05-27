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
}