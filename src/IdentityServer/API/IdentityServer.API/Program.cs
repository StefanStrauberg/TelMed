using IdentityServer.Application;
using IdentityServer.Application.Middleware;
using IdentityServer.Infrastructure;
using IdentityServer.Infrastructure.Persistence.Config;

var builder = WebApplication.CreateBuilder(args);

var _policyName = "CorsPolicy";
var jwtSettings = builder.Configuration.GetSection("JWTSettings");

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
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