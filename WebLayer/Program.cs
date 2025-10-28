using EntityFramework;
using Microsoft.EntityFrameworkCore;
using EntityFramework.DataServices;
using EntityFramework.Interfaces;
using Mapster; //only this was added in Program

var builder = WebApplication.CreateBuilder(args);

// Basic logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// register entity framework with the db context 
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//add Mapster
    builder.Services.AddMapster();

// register controllers and services
builder.Services.AddControllers();
builder.Services.AddScoped<IGenreData, GenreData>();
builder.Services.AddScoped<IEpisodeData, EpisodeData>();
builder.Services.AddScoped<ITitleData, TitleData>();
builder.Services.AddMapster(); //only this was added in Program

var app = builder.Build();

app.MapGet("/", () => Results.Text("Web app running"));

// enable attribute-routed controllers (api/genres)
app.MapControllers();

Console.WriteLine("Starting web host...");
Console.WriteLine("Listening on: " + (app.Urls.Count > 0 ? string.Join(", ", app.Urls) : "no explicit URLs (check ASPNETCORE_URLS or Kestrel config)"));

app.Run();