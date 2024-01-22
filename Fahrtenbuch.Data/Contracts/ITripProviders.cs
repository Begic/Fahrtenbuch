using Fahrtenbuch.Data.Models;

namespace Fahrtenbuch.Data.Contracts;

public interface ITripProviders
{
    Task<List<TripInfo>> GetAllTripsInfos(LoginInfo? userServiceCurrentUser);
    Task DeleteTrip(int id);
    Task EditTrip(LoginInfo? userServiceCurrentUser, EditTripInfo editTripInfoModel);
}