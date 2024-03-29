﻿namespace Fahrtenbuch.Data.Models;

public class TripInfo
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTimeStamp { get; set; }
    public DateTime? EndTimeStamp { get; set; }
    public string TravelRoute { get; set; }
    public string PurposeOfTrip { get; set; }
    public int? DepartureMileage { get; set; }
    public int? ArrivalMileage { get; set; }
    public int CompanyCarId { get; set; }
    public string CompanyCar { get; set; }
}