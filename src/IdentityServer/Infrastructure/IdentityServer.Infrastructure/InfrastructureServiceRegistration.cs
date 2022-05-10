using IdentityServer.Domain;
using IdentityServer.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<Account, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();
            return services;
        }
    }
}
