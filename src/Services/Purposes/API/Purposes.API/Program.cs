using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Purposes.Application;
using Purposes.Application.Middleware;
using Purposes.Infrastructure;
using Purposes.Infrastructure.Persistence.Config;

var builder = WebApplication.CreateBuilder(args);

const string _policyName = "CorsPolicy";

builder.Services.AddApplicationServices();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddInfrastructureServices();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.Authority = "http://localhost:5050";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "http://localhost:5050",
            ValidAudience = "PurposeApi"
        };
    });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _policyName, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
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
