using System.Text;

namespace JwtAuthentification.Infrastructure.Helpers;

public static class StringHelpers
{
    public static byte[] ConvertToAciiBytes(this string s) => Encoding.ASCII.GetBytes(s);
}
