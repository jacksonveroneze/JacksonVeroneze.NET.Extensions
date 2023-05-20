namespace JacksonVeroneze.NET.Extensions.Async;

public static partial class AsyncExtensions
{
    public static async Task<TType> FallbackAsync<TType>(
        this Task<TType> task, TType fallback)
    {
        try
        {
            return await task.ConfigureAwait(false);
        }
        catch
        {
            return fallback;
        }
    }
}