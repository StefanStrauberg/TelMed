using AutoMapper;
using FluentValidation;
using IdentityServer.Application.Behaviors;
using IdentityServer.Application.GrpcServices;
using IdentityServer.Application.Mappings;
using IdentityServer.Application.Middleware;
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
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<ExceptionHandlingMiddleware>();
            services.AddGrpcClient<SpecializationProtoService.SpecializationProtoServiceClient>
                (options => options.Address = new Uri(configuration["GrpcSettings:SpecializationUrl"]));
            services.AddGrpcClient<OrganizationProtoService.OrganizationProtoServiceClient>
                (options => options.Address = new Uri(configuration["GrpcSettings:OrganizationUrl"]));
            services.AddScoped<IGrpcService, GrpcService>();
            return services;
        }
    }
}
