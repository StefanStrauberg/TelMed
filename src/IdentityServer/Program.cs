using System.Text;
using IdentityServer.Data;
using IdentityServer.JwtFeatures;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
const string _policyName = "CorsPolicy";
var jwtSettings = builder.Configuration.GetSection("JWTSettings");

builder.Services.AddDbContext<ApplicationContext>(opt => 
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>();
builder.Services.AddScoped<JwtHandler>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddAuthentication(opt => 
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => 
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
        ValidAudience = jwtSettings.GetSection("validAudience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            jwtSettings.GetSection("securityKey").Value
        ))
    };
});
builder.Services.AddCors(options => 
                {
                    options.AddPolicy(name: _policyName,
                    set => set.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins(builder.Configuration["ServiceUrls:Angular"]));
                });

var app = builder.Build();

app.UseRouting();
app.UseCors(_policyName);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
