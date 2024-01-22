using Fahrtenbuch.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fahrtenbuch.Data;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<CompanyCar> CompanyCars { get; set; }
    public DbSet<Drive> Drives { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LogbookDb; Integrated Security=True;");
    }
}