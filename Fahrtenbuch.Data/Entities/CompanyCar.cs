using System.ComponentModel.DataAnnotations;

namespace Fahrtenbuch.Data.Entities;

public class CompanyCar
{
    [Key]
    public int Id { get; set; }
    [MaxLength(200)] public string Brand { get; set; }
    [MaxLength(200)] public string Type { get; set; }
    [MaxLength(200)] public string Registration { get; set; }

    public List<Drive> Drives { get; set; } = new();
}