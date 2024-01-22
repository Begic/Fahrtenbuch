using System.Security.Cryptography;
using System.Text;

namespace Fahrtenbuch.Data.Services;

public static class HashPassword
{
    public static byte[] Hash(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
           return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}