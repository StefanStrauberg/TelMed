using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Referrals.Application.Behaviours;
using Referrals.Application.Middleware;
using System.Reflection;

namespace Referrals.Application
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
            return services;
        }
    }
}
