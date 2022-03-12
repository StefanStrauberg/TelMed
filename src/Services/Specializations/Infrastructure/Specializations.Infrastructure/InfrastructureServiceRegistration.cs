using Microsoft.Extensions.DependencyInjection;
using Specializations.Application.Contracts.Persistence;
using Specializations.Infrastructure.Persistence;
using Specializations.Infrastructure.Repositories;

namespace Specializations.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ISpecializationContext, SpecializationContext>();
            services.AddScoped<ISpecializationRepository, SpecializationRepository>();
            return services;
        }
    }
}
