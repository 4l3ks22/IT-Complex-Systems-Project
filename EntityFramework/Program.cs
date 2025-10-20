using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Load connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with dependency injection
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Run the app
app.Run();