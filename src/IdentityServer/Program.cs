using IdentityServer.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
    .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
    .AddTestUsers(InMemoryConfig.GetTestUsers())
    .AddInMemoryClients(InMemoryConfig.GetClients())
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer();

app.MapGet("/", () => "Hello World!");

app.Run();
