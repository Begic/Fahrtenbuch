using Fahrtenbuch.Data.Contracts;
using Fahrtenbuch.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Fahrtenbuch.Data.Providers;

public class TripsProviders : ITripsProviders
{
    private readonly IDbContextFactory<DataBaseContext> factory;

    public TripsProviders(IDbContextFactory<DataBaseContext> factory)
    {
        this.factory = factory;
    }
    
    public async Task<List<TripInfo>> GetAllTripsInfos()
    {
        
    }
}