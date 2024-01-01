namespace JacksonVeroneze.NET.Extensions.IEnumerable;

public static class EnumerableExtensions
{
    public static IEnumerable<TType> Map<TType>(
        this IEnumerable<TType> input, Action<TType> action)
        where TType : class
    {
        ArgumentNullException.ThrowIfNull(input);
        ArgumentNullException.ThrowIfNull(action);

        return MapIterator(input, action);
    }

    private static IEnumerable<TType> MapIterator<TType>(
        this IEnumerable<TType> input, Action<TType> action)
        where TType : class
    {
        foreach (TType item in input)
        {
            action(item);
            yield return item;
        }
    }
}
