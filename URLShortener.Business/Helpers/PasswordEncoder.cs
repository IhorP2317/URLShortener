using System.Security.Cryptography;
using System.Text;

namespace URLShortener.Bussiness.Helpers;

public class PasswordEncoder
{
    public static string HashPassword(string password)
    {
        var md5 = new MD5CryptoServiceProvider();
        var fromData = Encoding.UTF8.GetBytes(password);
        var targetData = md5.ComputeHash(fromData);

        return targetData.Aggregate<byte, string>(null, (current, t) => current + t.ToString("x2"));
    }
}