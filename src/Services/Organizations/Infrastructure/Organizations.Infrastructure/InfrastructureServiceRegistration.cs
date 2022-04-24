using Microsoft.Extensions.DependencyInjection;
using Organizations.Application.Contracts.Persistence;
using Organizations.Infrastructure.Persistence;
using Organizations.Infrastructure.Repositories;

namespace Organizations.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationContext, OrganizationContext>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            return services;
        }
    }
}
