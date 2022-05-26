using FluentValidation;
using IdentityServer.GRPC;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Referrals.Application.Behaviours;
using Referrals.Application.Consumers;
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
            services.AddTransient<ReferralConsumer>();
             services.AddMassTransit(x =>
            {
                x.AddConsumer<ReferralConsumer>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ReceiveEndpoint("AnamnesisQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<ReferralConsumer>(provider);
                    });
                }));
            });
            return services;
        }
    }
}
