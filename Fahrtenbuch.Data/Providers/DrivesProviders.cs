using Fahrtenbuch.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Fahrtenbuch.Data.Providers;

public class DrivesProviders : IDrivesProviders
{
    private readonly IDbContextFactory<DataBaseContext> factory;

    public DrivesProviders(IDbContextFactory<DataBaseContext> factory)
    {
        this.factory = factory;
    }
    
    
}