using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Load connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with dependency injection
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Optional: minimal endpoint
app.MapGet("/", () => "Hello World!");

// Run the app
app.Run();