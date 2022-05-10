using Specialization.GRPC.DbContexts;
using Specialization.GRPC.DbContexts.Config;
using Specialization.GRPC.Repositories;
using Specialization.GRPC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IMongoSpecContext, MongoSpecContext>();
builder.Services.AddScoped<ISpecializationRepository, SpecializationRepository>();
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<SpecializationService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
