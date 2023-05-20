namespace JacksonVeroneze.NET.Extensions.Async;

public static partial class AsyncExtensions
{
    public static async Task RetryAsync(
        this Func<Task> func, int maxRetries, TimeSpan delay)
    {
        for (int i = 1; i <= maxRetries; i++)
        {
            try
            {
                await func().ConfigureAwait(false);

                return;
            }
            catch
            {
                if (i == maxRetries)
                {
                    throw;
                }

                await Task.Delay(delay).ConfigureAwait(false);
            }
        }
    }
}