using Fahrtenbuch.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fahrtenbuch.Data;

public class DataBaseContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<CompanyCar> CompanyCars { get; set; }
    public DbSet<Trip> Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LogbookDb; Integrated Security=True;");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasMany(x => x.CompanyCars)
            .WithMany(x => x.Employees);
    }
}