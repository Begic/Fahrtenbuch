using Fahrtenbuch.Data.Models;

namespace Fahrtenbuch.Data.Services;

public class UserService
{
    public LoginInfo? CurrentUser { get; set; }
}