namespace JacksonVeroneze.NET.Extensions.Async;

public static partial class AsyncExtensions
{
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