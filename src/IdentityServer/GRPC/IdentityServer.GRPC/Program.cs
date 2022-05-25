using IdentityServer.GRPC.DbContexts;
using IdentityServer.GRPC.DbContexts.Config;
using IdentityServer.GRPC.Repositories;
using IdentityServer.GRPC.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IIdentityContext, IdentityContext>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<ApplicationUserService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
