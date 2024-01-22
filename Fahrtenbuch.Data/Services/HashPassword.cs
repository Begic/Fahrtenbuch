using System.Security.Cryptography;
using System.Text;

namespace Fahrtenbuch.Data.Services;

public static class HashPassword
{
    public static byte[] Hash(string passwort)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwort));
            
            var ka =  BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            return new byte[0];
        }
    }
}