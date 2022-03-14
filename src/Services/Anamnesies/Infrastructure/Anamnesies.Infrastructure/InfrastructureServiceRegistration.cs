using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Referrals.Infrastructure.Repositories;

namespace Anamnesies.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAnamnesisContext, AnamnesisContext>();
            services.AddScoped<IAnamnesisRepository, AnamnesisRepository>();
            return services;
        }
    }
}
