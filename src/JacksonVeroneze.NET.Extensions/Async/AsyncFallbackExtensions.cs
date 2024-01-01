namespace JacksonVeroneze.NET.Extensions.Async;

public static partial class AsyncExtensions
{
    public static async Task<TType> FallbackAsync<TType>(
        this Task<TType> task, TType fallback)
    {
        ArgumentNullException.ThrowIfNull(task);

        try
        {
            TType result = await task.ConfigureAwait(false);

            return result;
        }
        catch
        {
            return fallback;
        }
    }
}
