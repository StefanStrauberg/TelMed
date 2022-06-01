using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Organizations.Application.Contracts.Persistence;

namespace Organizations.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(configuration.GetConnectionString("DatabaseName")));
            services.AddScoped((typeof(IGenericRepository<>)), (typeof(GenericRepository<>)));
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
