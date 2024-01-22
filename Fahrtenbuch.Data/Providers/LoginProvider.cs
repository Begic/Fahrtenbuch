using Fahrtenbuch.Data.Contracts;
using Fahrtenbuch.Data.Models;

namespace Fahrtenbuch.Data.Providers;

public class LoginProvider : ILoginProvider
{
    public async Task<LoginInfo> CheckUserForLogin(LoginInfo loginModel)
    {
        return null;
    }
}