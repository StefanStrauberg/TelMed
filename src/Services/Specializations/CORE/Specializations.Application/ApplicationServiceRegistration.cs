using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Specializations.Application.Behaviours;
using System.Reflection;

namespace Specializations.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddSpecializationServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
