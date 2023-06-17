namespace JacksonVeroneze.NET.Extensions.Async;

public static partial class AsyncExtensions
{
    public static async Task WhenAllSequentialAsync(
        this IEnumerable<Task> tasks)
    {
        ArgumentNullException.ThrowIfNull(tasks);

        foreach (Task task in tasks)
        {
            await task.ConfigureAwait(false);
        }
    }

    public static async Task WhenAllParallelAsync(
        this IEnumerable<Task> tasks, int degree)
    {
        ArgumentNullException.ThrowIfNull(tasks);

        foreach (Task[] chunk in tasks.Chunk(degree))
        {
            await Task.WhenAll(chunk)
                .ConfigureAwait(false);
        }
    }
}
