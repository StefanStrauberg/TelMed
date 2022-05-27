using Microsoft.Extensions.DependencyInjection;
using Purposes.Application.Contracts.Persistence;
using Purposes.Infrastructure.Persistence;
using Purposes.Infrastructure.Repositories;

namespace Purposes.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPurposeContext, PurposeContext>();
            services.AddScoped<IPurposeRepository, PurposeRepository>();
            return services;
        }
    }
}
