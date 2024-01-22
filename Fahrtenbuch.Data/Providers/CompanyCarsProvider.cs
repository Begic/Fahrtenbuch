using Fahrtenbuch.Data.Contracts;
using Fahrtenbuch.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Fahrtenbuch.Data.Providers;

public class CompanyCarsProvider : ICompanyCarsProvider
{
    private readonly IDbContextFactory<DataBaseContext> factory;

    public CompanyCarsProvider(IDbContextFactory<DataBaseContext> factory)
    {
        this.factory = factory;
    }

    public async Task<List<CompanyCarInfo>> GetAllCompanyCars()
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);
        return await db.CompanyCars.Select(x => new CompanyCarInfo
        {
            Id = x.Id,
            Brand = x.Brand,
            Type = x.Type,
            LicensePlate = x.LicensePlate
        }).ToListAsync();
    }
}