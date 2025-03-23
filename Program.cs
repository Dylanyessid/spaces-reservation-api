using Microsoft.EntityFrameworkCore;
using SpacesReservation.API.Services;
using SpacesReservation.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SpacesReservation.API.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//Inject all services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProfileService, ProfileService>();

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "yourdomain.com",
            ValidAudience = "yourdomain.com",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key"))
        };
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCorsPolicy", policyBuilder =>
    {
        policyBuilder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials(); // Si vas a usar cookies o auth tipo JWT en header
    });
});


var app = builder.Build();




// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
