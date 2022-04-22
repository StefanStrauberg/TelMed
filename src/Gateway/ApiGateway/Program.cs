using Ocelot.DependencyInjection;
using Ocelot.Middleware;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();
const string _policyName = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot(configuration);
builder.Services.AddCors(options => {
    options.AddPolicy(_policyName, policy => {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var app = builder.Build();

app.UseRouting();
app.UseCors(_policyName);
app.UseEndpoints(edpoint =>
{
    edpoint.MapControllers();
});
await app.UseOcelot();

app.Run();
