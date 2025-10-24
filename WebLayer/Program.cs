using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EntityFramework.DataServices;
using EntityFramework.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// register EF Core with Npgsql 
builder.Services.AddDbContext<EntityFramework.Models.MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// register controllers and service
builder.Services.AddControllers();
builder.Services.AddScoped<IGenreData, GenreData>();

var app = builder.Build();

app.MapGet("/", () => Results.Text("Web app running"));

// enable attribute-routed controllers (api/genres)
app.MapControllers();

Console.WriteLine("Starting web host...");
Console.WriteLine("Listening on: " + (app.Urls.Count > 0 ? string.Join(", ", app.Urls) : "no explicit URLs (check ASPNETCORE_URLS or Kestrel config)"));

app.Run();