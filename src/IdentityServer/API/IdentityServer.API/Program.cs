using IdentityServer.Application;
using IdentityServer.Application.Middleware;
using IdentityServer.Domain;
using IdentityServer.Infrastructure;
using IdentityServer.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var _policyName = "CorsPolicy";
var jwtSettings = builder.Configuration.GetSection("JWTSettings");

//builder.Services.AddDbContext<ApplicationContext>(opt =>
//    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddIdentity<Account, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationContext>();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _policyName,
    set => set.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins(builder.Configuration["ServiceUrls:Angular"]));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRouting();
app.UseCors(_policyName);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
