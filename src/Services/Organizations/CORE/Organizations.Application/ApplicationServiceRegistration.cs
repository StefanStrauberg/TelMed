using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Organizations.Application.Behaviors;
using Organizations.Application.GrpcServices;
using Organizations.Application.Middleware;
using Specialization.GRPC;
using System.Reflection;

namespace Organizations.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<ExceptionHandlingMiddleware>();
            services.AddGrpcClient<SpecializationProtoService.SpecializationProtoServiceClient>
                (options => options.Address = new Uri(config["GrpcSettings:SpecializationUrl"]));
            services.AddScoped<SpecializationGrpcService>();
            return services;
        }
    }
}
