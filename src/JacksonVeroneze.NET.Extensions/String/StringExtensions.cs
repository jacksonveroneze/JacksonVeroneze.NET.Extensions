using System.Security.Cryptography;
using System.Text;

namespace JacksonVeroneze.NET.Extensions.String;

public static class StringExtensions
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

    public static string ToMd5Hash(this string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        byte[] bytes = Encoding.UTF8.GetBytes(input);

        using HashAlgorithm? algo = HashAlgorithm.Create(nameof(MD5));

        byte[] hash = algo!.ComputeHash(bytes);

        return Convert.ToHexString(hash);
    }
}
