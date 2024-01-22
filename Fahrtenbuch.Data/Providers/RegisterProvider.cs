using Fahrtenbuch.Data.Contracts;
using Fahrtenbuch.Data.Entities;
using Fahrtenbuch.Data.Models;
using Fahrtenbuch.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Fahrtenbuch.Data.Providers;

public class RegisterProvider : IRegisterProvider
{
    private readonly IDbContextFactory<DataBaseContext> factory;

    public RegisterProvider(IDbContextFactory<DataBaseContext> factory)
    {
        this.factory = factory;
    }

    public async Task AddUser(RegisterInfo registerInfoToEdit)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);
        await db.Employees.AddAsync(new Employee
        { 
            FirstName = registerInfoToEdit.FirstName,
            LastName = registerInfoToEdit.LastName,
            Email = registerInfoToEdit.Email,
            Password = HashPassword.Hash(registerInfoToEdit.LoginPassword)
        });

        await db.SaveChangesAsync();
    }
}