using System.Security.Cryptography;
using System.Text;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using EntityFramework.DataServices;
using EntityFramework.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebLayer.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Load appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// ➤ Add CORS so React can call your API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins(
            "http://localhost:5173"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
    );
});

// DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Mapster
builder.Services.AddMapster();
var config = TypeAdapterConfig.GlobalSettings;
MappingConfig.Register(config);

// Controllers & Services
builder.Services.AddControllers();
builder.Services.AddScoped<IGenreData, GenreData>();
builder.Services.AddScoped<IEpisodeData, EpisodeData>();
builder.Services.AddScoped<ITitleData, TitleData>();
builder.Services.AddScoped<IPersonData, PersonData>();
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IVersionData, VersionData>();
builder.Services.AddScoped<ITitleGenreData, TitleGenreData>();

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();


var app = builder.Build();

app.MapGet("/", () => Results.Text("Web app running"));

// ➤ Important order: CORS must be BEFORE auth & controllers
app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

Console.WriteLine("Starting web host...");
Console.WriteLine("Listening on: " + 
    (app.Urls.Count > 0 ? string.Join(", ", app.Urls) : "no explicit URLs"));

app.Run();
