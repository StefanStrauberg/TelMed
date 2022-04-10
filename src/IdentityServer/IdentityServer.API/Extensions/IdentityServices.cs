using System.Text;
using IdentityServer.Core.Entities;
using IdentityServer.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.API.Extensions
{
    public static class IdentityServices
    {
        public static IServiceCollection AddIdentityServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            var builder = services.AddIdentityCore<Account>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<ApplicationDbContext>();
            builder.AddSignInManager<SignInManager<Account>>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });
            return services;
        }
    }
}