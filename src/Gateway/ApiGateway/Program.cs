using Ocelot.DependencyInjection;
using Ocelot.Middleware;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot(configuration);
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var app = builder.Build();


app.UseRouting();

app.UseCors("CorsPolicy");

app.UseEndpoints(edpoint =>
{
    edpoint.MapControllers();
});

await app.UseOcelot();

app.Run();
