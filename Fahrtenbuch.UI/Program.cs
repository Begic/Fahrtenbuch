using Fahrtenbuch.Data;
using Fahrtenbuch.Data.Contracts;
using Fahrtenbuch.Data.Entities;
using Fahrtenbuch.Data.Providers;
using Fahrtenbuch.Data.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices(
    conf => conf.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight);

builder.Services.AddScoped<UserService>();
builder.Services.AddTransient<IDrivesProviders, DrivesProviders>();
builder.Services.AddTransient<ILoginProvider, LoginProvider>();
builder.Services.AddTransient<IRegisterProvider, RegisterProvider>();

builder.Services.AddDbContextFactory<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(
        "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=LogbookDb; Integrated Security=True;")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var db = scope.ServiceProvider.GetService<IDbContextFactory<DataBaseContext>>()?.CreateDbContext())
{
    await db.Database.MigrateAsync();

    if (!db.Employees.Any())
        await db.Employees.AddAsync(new Employee
        {
            FirstName = "Max",
            LastName = "Mustermann",
            Email = "max@mail.muster",
            Password = HashPassword.Hash("passwort")
        });

    if (!db.CompanyCars.Any())
        await db.CompanyCars.AddAsync(new CompanyCar
        {
            Brand = "Bmw",
            Type = "M5 CS",
            LicensePlate = "KU 777 YB"
        });

    await db.SaveChangesAsync();
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();