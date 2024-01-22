using System.ComponentModel.DataAnnotations;

namespace Fahrtenbuch.Data.Entities;

public class Drive
{
    [Key] public int Id { get; set; }

    public DateTime Date { get; set; }
    public DateTime StartTimeStamp { get; set; }
    public DateTime? EndTimeStamp { get; set; }
    [MaxLength(2000)] public string TravelRoute { get; set; }
    [MaxLength(2000)] public string PurposeOfTrip { get; set; }
    public int? DepartureMileage { get; set; }
    public int? ArrivalMileage { get; set; }

    public Employee Employee { get; set; }
    public int EmployeeId { get; set; }

    public CompanyCar CompanyCar { get; set; }
    public int CompanyCarId { get; set; }
}