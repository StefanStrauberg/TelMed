using IdentityServer.Application;
using IdentityServer.Application.Middleware;
using IdentityServer.Infrastructure;
using IdentityServer.Infrastructure.Persistence.Config;

var builder = WebApplication.CreateBuilder(args);
const string _policyName = "CorsPolicy";

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddControllersWithViews();
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

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(_policyName);
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None,
    Secure = CookieSecurePolicy.Always,
});
app.UseIdentityServer();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();