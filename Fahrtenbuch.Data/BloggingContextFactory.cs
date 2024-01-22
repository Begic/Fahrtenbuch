using Microsoft.EntityFrameworkCore;

namespace Fahrtenbuch.Data;

public class BloggingContextFactory
{
    public DataBaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
        optionsBuilder.UseSqlServer(
            "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=LogbookDb; Integrated Security=True;");

        return new DataBaseContext(optionsBuilder.Options);
    }
}