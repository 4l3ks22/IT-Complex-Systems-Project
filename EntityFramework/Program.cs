using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

var builder = WebApplication.CreateBuilder(args);

// Load connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register MyDbContext with dependency injection
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

app.Run();