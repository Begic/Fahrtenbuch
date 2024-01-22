using Fahrtenbuch.Data;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddMudServices(
    conf => conf.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight);

//builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContextFactory<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=LogbookDb; Integrated Security=True;")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var db = scope.ServiceProvider.GetService<IDbContextFactory<DataBaseContext>>()?.CreateDbContext())
{
    await db.Database.MigrateAsync();
    
    if (!db.Employees.Any())
    {
        
    }
    
    if (!db.CompanyCars.Any())
    {
        
    }
    
    if (!db.Drives.Any())
    {
        
    }

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