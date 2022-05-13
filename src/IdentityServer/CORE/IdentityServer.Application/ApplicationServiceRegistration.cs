using FluentValidation;
using IdentityServer.Application.Behaviors;
using IdentityServer.Application.GrpcServices;
using IdentityServer.Application.Middleware;
using IdentityServer.Application.Security;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Organization.GRPC;
using Specialization.GRPC;
using System.Reflection;

namespace IdentityServer.Application
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
            services.AddScoped<JwtHandler>();
            services.AddGrpcClient<SpecializationProtoService.SpecializationProtoServiceClient>
                (options => options.Address = new Uri(config["GrpcSettings:SpecializationUrl"]));
            services.AddGrpcClient<OrganizationProtoService.OrganizationProtoServiceClient>
                (options => options.Address = new Uri(config["GrpcSettings:OrganizationUrl"]));
            services.AddScoped<IGrpcService, GrpcService>();
            return services;
        }
    }
}
