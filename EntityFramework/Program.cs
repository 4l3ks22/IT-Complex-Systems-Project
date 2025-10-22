using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

Console.WriteLine("Testing EF Core layer...");


var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
optionsBuilder.UseNpgsql("Host=cit.ruc.dk;Database=cit08;username=cit08;password=;");

using var context = new MyDbContext(optionsBuilder.Options);

var episodes = await context.Episodes.ToListAsync();
foreach (var e in episodes)
{
    Console.WriteLine($"{e.Episodenumber}: {e.Tconst}");
}