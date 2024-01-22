using System.ComponentModel.DataAnnotations;

namespace Fahrtenbuch.Data.Entities;

public class Employee
{
    [Key]
    public int Id { get; set; }
    [MaxLength(200)] public string FirstName { get; set; }
    [MaxLength(200)] public string LastName { get; set; }
    [MaxLength(200)] public string Email { get; set; }
    public byte[] Passwort { get; set; }

    public List<Drive> Drives { get; set; } = new();
}