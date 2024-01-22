namespace Fahrtenbuch.Data.Models;

public class LoginInfo
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public byte[] HashedPassword { get; set; }
}