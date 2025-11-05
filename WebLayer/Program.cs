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
using WebLayer.Mappings; //only this was added in Program

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

// Mapster configuration 
var config = TypeAdapterConfig.GlobalSettings;
MappingConfig.Register(config);

// register controllers and services
builder.Services.AddControllers();
builder.Services.AddScoped<IGenreData, GenreData>();
builder.Services.AddScoped<IEpisodeData, EpisodeData>();
builder.Services.AddScoped<ITitleData, TitleData>();
builder.Services.AddScoped<IPersonData, PersonData>();
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IVersionData, VersionData>();
builder.Services.AddScoped<ITitleGenreData, TitleGenreData>();

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

// enable attribute-routed controllers (api/genres)
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

Console.WriteLine("Starting web host...");
Console.WriteLine("Listening on: " + (app.Urls.Count > 0 ? string.Join(", ", app.Urls) : "no explicit URLs (check ASPNETCORE_URLS or Kestrel config)"));

app.Run();