using Organization.GRPC.DbContexts;
using Organization.GRPC.DbContexts.Config;
using Organization.GRPC.Repositories;
using Organization.GRPC.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IMongoOrgContext, MongoOrgContext>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<OrganizationService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
