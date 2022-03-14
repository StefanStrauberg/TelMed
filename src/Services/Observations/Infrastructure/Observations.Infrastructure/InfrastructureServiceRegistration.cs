using Microsoft.Extensions.DependencyInjection;
using Observations.Application.Contracts.Persistence;
using Observations.Infrastructure.Persistence;
using Observations.Infrastructure.Repositories;

namespace Observations.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IObservationContext, ObservationContext>();
            services.AddScoped<IObservationsRepository, ObservationRepository>();
            return services;
        }
    }
}
