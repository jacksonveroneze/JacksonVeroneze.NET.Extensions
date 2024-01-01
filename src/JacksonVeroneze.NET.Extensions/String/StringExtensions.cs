namespace JacksonVeroneze.NET.Extensions.String;

public static partial class StringExtensions
{
    public static string ToUpperFirstCharacter(this string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        return string.Create(input.Length, input, static (chars, str) =>
        {
            chars[0] = char.ToUpperInvariant(str[0]);

            str.AsSpan(1).CopyTo(chars[1..]);
        });
    }

    public static string Reverse(this string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        char[] reversed = input.ToCharArray();

        return new string(reversed);
    }
}
