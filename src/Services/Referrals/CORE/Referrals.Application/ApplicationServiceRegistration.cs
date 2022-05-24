using FluentValidation;
using IdentityServer.GRPC;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Referrals.Application.Behaviours;
using Referrals.Application.GrpcServices;
using Referrals.Application.Middleware;
using System.Reflection;

namespace Referrals.Application
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
            services.AddGrpcClient<IdentityServerProtoService.IdentityServerProtoServiceClient>
                (options => options.Address = new Uri(config["GrpcSettings:IdentityServerUrl"]));
            services.AddScoped<IGrpcService, GrpcService>();
            return services;
        }
    }
}
