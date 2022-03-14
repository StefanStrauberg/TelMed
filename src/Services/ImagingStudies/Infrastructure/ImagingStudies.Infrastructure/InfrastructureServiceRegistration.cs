using ImagingStudies.Application.Contracts.Persistence;
using ImagingStudies.Infrastructure.Persistence;
using ImagingStudies.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ImagingStudies.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IImagingStudyContext, ImagingStudyContext>();
            services.AddScoped<IImagingStudyRepository, ImagingStudyRepository>();
            return services;
        }
    }
}
