using Xunit.Abstractions;

namespace JacksonVeroneze.NET.Extensions.UnitTests.Async;

public class AsyncTimeoutExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AsyncTimeoutExtensionsTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
}