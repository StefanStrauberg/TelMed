using FluentValidation;
using IdentityServer.Application.Behaviors;
using IdentityServer.Application.Middleware;
using IdentityServer.Application.Security;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IdentityServer.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<ExceptionHandlingMiddleware>();
            services.AddScoped<JwtHandler>();
            return services;
        }
    }
}
