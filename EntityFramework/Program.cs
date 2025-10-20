using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

Console.WriteLine("Testing EF Core layer...");

// Example: manually configure DbContext (for testing only)
var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
optionsBuilder.UseNpgsql("Host=localhost;Database=mydb;Username=myuser;Password=mysecret;");

using var context = new MyDbContext(optionsBuilder.Options);

var episodes = await context.Episodes.ToListAsync();
foreach (var e in episodes)
{
    Console.WriteLine($"{e.Episodenumber}: {e.Tconst}");
}