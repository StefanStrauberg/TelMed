using System.Text;
using IdentityServer.API.Data;
using IdentityServer.API.JWTFeatures;
using IdentityServer.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var _policyName = "CorsPolicy";
var jwtSettings = builder.Configuration.GetSection("JWTSettings");

builder.Services.AddDbContext<ApplicationContext>(opt => 
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<Account, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>();
builder.Services.AddScoped<JwtHandler>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors(_policyName);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
