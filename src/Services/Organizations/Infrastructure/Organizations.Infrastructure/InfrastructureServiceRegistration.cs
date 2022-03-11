using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Organizations.Application.Contracts.Persistence;
using Organizations.Infrastructure.Persistence;
using Organizations.Infrastructure.Persistence.Config;
using Organizations.Infrastructure.Repositories;

namespace Organizations.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(x => configuration.GetSection("DatabaseSettings"));
            services.AddScoped<IOrganizationContext, OrganizationContext>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            return services;
        }
    }
}
