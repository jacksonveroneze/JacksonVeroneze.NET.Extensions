using System.Security.Cryptography;
using System.Text;

namespace JacksonVeroneze.NET.Extensions.String;

public static partial class StringExtensions
{
    public static string ToMd5Hash(this string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        byte[] bytes = Encoding.UTF8.GetBytes(input);

        using HashAlgorithm? algo = HashAlgorithm.Create(nameof(MD5));

        byte[] hash = algo!.ComputeHash(bytes);

        return Convert.ToHexString(hash);
    }

    public static string ToSha256Hash(this string input)
    {
        byte[] bytes = SHA256.HashData(
            Encoding.UTF8.GetBytes(input));

        StringBuilder builder = new();

        foreach (byte t in bytes)
        {
            //builder.Append(t.ToString("x2"));
        }

        return builder.ToString();
    }
}
