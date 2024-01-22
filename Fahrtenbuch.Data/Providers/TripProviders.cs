using Fahrtenbuch.Data.Contracts;
using Fahrtenbuch.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Fahrtenbuch.Data.Providers;

public class TripProviders : ITripProviders
{
    private readonly IDbContextFactory<DataBaseContext> factory;

    public TripProviders(IDbContextFactory<DataBaseContext> factory)
    {
        this.factory = factory;
    }

    public async Task<List<TripInfo>> GetAllTripsInfos(LoginInfo? currentUser)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);
        return await db.Trips.Where(x => x.EmployeeId == currentUser.Id)
            .Select(x => new TripInfo
            {
                Id = x.Id,
                Date = x.Date,
                StartTimeStamp = x.StartTimeStamp,
                EndTimeStamp = x.EndTimeStamp,
                TravelRoute = x.TravelRoute,
                PurposeOfTrip = x.PurposeOfTrip,
                DepartureMileage = x.DepartureMileage,
                ArrivalMileage = x.ArrivalMileage,
                CompanyCarId = x.CompanyCarId,
                CompanyCar = x.CompanyCar.Brand + " | " + x.CompanyCar.Type + " | " + x.CompanyCar.LicensePlate
            }).ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task DeleteTrip(int tripId)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);
        var toDelete = await db.Trips.FirstOrDefaultAsync(x => x.Id == tripId).ConfigureAwait(false);

        if (toDelete != null)
        {
            db.Trips.Remove(toDelete);

            await db.SaveChangesAsync();
        }
    }

    public async Task EditTrip(LoginInfo? userServiceCurrentUser, EditTripInfo editTripInfoModel)
    {
        
    }
}