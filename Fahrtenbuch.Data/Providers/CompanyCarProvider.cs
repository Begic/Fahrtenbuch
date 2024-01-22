using Fahrtenbuch.Data.Contracts;
using Fahrtenbuch.Data.Entities;
using Fahrtenbuch.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Fahrtenbuch.Data.Providers;

public class CompanyCarProvider : ICompanyCarProvider
{
    private readonly IDbContextFactory<DataBaseContext> factory;

    public CompanyCarProvider(IDbContextFactory<DataBaseContext> factory)
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
        }).ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task DeleteCompanyCar(int carId)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);
        var toDelete = await db.CompanyCars.FirstOrDefaultAsync(x => x.Id == carId).ConfigureAwait(false);

        if (toDelete != null)
        {
            db.CompanyCars.Remove(toDelete);

            await db.SaveChangesAsync();
        }
    }

    public async Task EditCompanyCar(EditCompanyCarInfo editModel)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);
        var toAdd = await db.CompanyCars.FirstOrDefaultAsync(x => x.Id == editModel.Id).ConfigureAwait(false);

        if (toAdd == null)
        {
            await db.CompanyCars.AddAsync(toAdd = new CompanyCar());
        }

        toAdd.Brand = editModel.Brand;
        toAdd.Type = editModel.Type;
        toAdd.LicensePlate = editModel.LicensePlate;

        await db.SaveChangesAsync();
    }
}