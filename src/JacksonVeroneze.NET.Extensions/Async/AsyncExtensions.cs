namespace JacksonVeroneze.NET.Extensions.Async;

public static class AsyncExtensions
{
    public static async Task TryAsync(
        this Task task,
        Action<Exception>? errorHandler = null)
    {
        try
        {
            await task.ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            if (errorHandler is null)
            {
                throw;
            }

            errorHandler(ex);
        }
    }

    public static async Task WhenAllSequentialAsync(
        this IEnumerable<Task> tasks)
    {
        foreach (Task task in tasks)
        {
            await task.ConfigureAwait(false);
        }
    }

    public static async Task WhenAllParallelAsync(
        this IEnumerable<Task> tasks, int degree)
    {
        foreach (Task[] chunk in tasks.Chunk(degree))
        {
            await Task.WhenAll(chunk)
                .ConfigureAwait(false);
        }
    }

    public static async Task<TType> OnlyOneAsync<TType>(
        this IEnumerable<Func<CancellationToken, Task<TType>>> funcs)
    {
        CancellationTokenSource cancellationTokenSource = new();

        IEnumerable<Task<TType>> tasks = funcs
            .Select(func => func(cancellationTokenSource.Token));

        Task<TType> first = await Task.WhenAny(tasks)
            .ConfigureAwait(false);
        
        cancellationTokenSource.Cancel();

        return await first
            .ConfigureAwait(false);
    }
}