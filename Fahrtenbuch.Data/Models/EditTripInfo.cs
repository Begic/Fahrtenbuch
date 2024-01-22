namespace Fahrtenbuch.Data.Models;

public class EditTripInfo
{
    public int Id { get; set; }
    public DateTime? Date { get; set; }
    public TimeSpan StartTimeStamp { get; set; }
    public TimeSpan? EndTimeStamp { get; set; }
    public string TravelRoute { get; set; }
    public string PurposeOfTrip { get; set; }
    public int? DepartureMileage { get; set; }
    public int? ArrivalMileage { get; set; }
    public string CompanyCar { get; set; }
    public int CompanyCarId { get; set; }
}