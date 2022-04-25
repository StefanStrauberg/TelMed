using Specialization.GRPC.DbContexts;
using Specialization.GRPC.Repositories;
using Specialization.GRPC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMongoSpecContext, MongoSpecContext>();
builder.Services.AddScoped<ISpecializationRepository, SpecializationRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<SpecializationService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
