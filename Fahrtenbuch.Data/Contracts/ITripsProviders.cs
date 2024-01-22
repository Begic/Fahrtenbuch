using Fahrtenbuch.Data.Models;

namespace Fahrtenbuch.Data.Contracts;

public interface ITripsProviders
{
    Task<List<TripInfo>> GetAllTripsInfos();
}