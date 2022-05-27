using IdentityServer.Domain;
using IdentityServer.GRPC.Repositories;
using IdentityServer.GRPC.Services;
using IdentityServer.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RepositoryContext>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<RepositoryContext>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<ApplicationUserService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
