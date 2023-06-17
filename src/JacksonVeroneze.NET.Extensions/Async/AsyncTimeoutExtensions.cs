namespace JacksonVeroneze.NET.Extensions.Async;

public static partial class AsyncExtensions
{
    public static async Task AwaitUntilTimeoutAsync(
        this Task task, TimeSpan timeout)
    {
        ArgumentNullException.ThrowIfNull(task);

        Task timeoutTask = Task.Delay(timeout);

        Task completedTask = await Task
            .WhenAny(task, timeoutTask)
            .ConfigureAwait(false);

        if (completedTask == timeoutTask)
        {
            return;
        }

        await task;
    }

    public static async Task WithTimeoutAsync(
        this Task task, TimeSpan timeout)
    {
        ArgumentNullException.ThrowIfNull(task);

        Task timeoutTask = Task.Delay(timeout);

        Task completedTask = await Task
            .WhenAny(task, timeoutTask)
            .ConfigureAwait(false);

        if (completedTask == timeoutTask)
        {
            throw new TimeoutException();
        }

        await task;
    }

    public static async Task<TType> WithTimeoutAsync<TType>(
        this Task<TType> task, TimeSpan timeout)
    {
        ArgumentNullException.ThrowIfNull(task);

        Task timeoutTask = Task.Delay(timeout);

        Task completedTask = await Task
            .WhenAny(task, timeoutTask)
            .ConfigureAwait(false);

        if (completedTask == timeoutTask)
        {
            throw new TimeoutException();
        }

        return await task;
    }
}
