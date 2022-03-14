using Microsoft.Extensions.DependencyInjection;
using Referrals.Application.Contracts.Persistence;
using Referrals.Infrastructure.Persistence;
using Referrals.Infrastructure.Repositories;

namespace Referrals.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IReferralContext, ReferralContext>();
            services.AddScoped<IReferralRepository, ReferralRepository>();
            return services;
        }
    }
}
