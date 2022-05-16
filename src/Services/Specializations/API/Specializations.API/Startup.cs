using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Specializations.Application;
using Specializations.Application.Middleware;
using Specializations.Infrastructure;
using Specializations.Infrastructure.Persistence.Config;

namespace Specializations.API
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
            services.AddInfrastructureServices();
            services.AddApplicationServices();
            services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = "http://localhost:5050";
                    options.Audience = "companyApi";
                });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Specializations.API", Version = "v1" });
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
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Specializations.API v1"));
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseRouting();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.None,
                Secure = CookieSecurePolicy.Always,
            });
            app.UseCors(_policyName);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
