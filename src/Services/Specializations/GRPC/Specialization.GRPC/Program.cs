using Microsoft.EntityFrameworkCore;
using Specialization.GRPC.Services;
using Specializations.Application.Contracts.Persistence;
using Specializations.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("DatabaseName")));
builder.Services.AddScoped((typeof(IGenericRepository<>)), (typeof(GenericRepository<>)));
builder.Services.AddScoped<ISpecializationCommandRepository, SpecializationRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<SpecializationService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
