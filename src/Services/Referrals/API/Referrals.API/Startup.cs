using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Referrals.Application;
using Referrals.Application.Middleware;
using Referrals.Infrastructure;
using Referrals.Infrastructure.Persistence.Config;

namespace Referrals.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly string _policyName = "CorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices();
            services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));
            services.AddInfrastructureServices();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Referrals.API", Version = "v1" });
            });
            services.AddCors(options => 
                {
                    options.AddPolicy(name: _policyName,
                    builder => builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins(Configuration["ServiceUrls:Angular"]));
                });
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Referrals.API v1"));
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseRouting();
            app.UseCors(_policyName);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
