using Fahrtenbuch.Data.Contracts;
using Fahrtenbuch.Data.Models;
using Fahrtenbuch.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Fahrtenbuch.Data.Providers;

public class LoginProvider : ILoginProvider
{
    private readonly IDbContextFactory<DataBaseContext> factory;

    public LoginProvider(IDbContextFactory<DataBaseContext> factory)
    {
        this.factory = factory;
    }
    public async Task<LoginInfo?> CheckUserForLogin(LoginInfo loginModel)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);
        foreach (var user in await db.Employees.ToListAsync())
        {
            var loginModelPassword = HashPassword.Hash(loginModel.Password);
            var ka = user.Password;
            
            if (user.Email == loginModel.Email && 
                user.Password == loginModelPassword)
            {
                return new LoginInfo
                {
                    Id = user.Id,
                    Email = user.Email,
                    HashedPassword = user.Password
                };
            }
        }
        return null;
    }
}