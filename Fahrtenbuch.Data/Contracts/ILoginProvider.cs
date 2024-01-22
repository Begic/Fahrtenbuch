using Fahrtenbuch.Data.Models;

namespace Fahrtenbuch.Data.Contracts;

public interface ILoginProvider
{
    Task<LoginInfo> CheckUserForLogin(LoginInfo loginModel);
}