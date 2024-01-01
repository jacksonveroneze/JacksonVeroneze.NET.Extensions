namespace JacksonVeroneze.NET.Extensions.Async;

public static partial class AsyncExtensions
{
    public static async Task TryAsync(
        this Task task, Action<Exception>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(task);

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
}
