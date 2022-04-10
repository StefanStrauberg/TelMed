using IdentityServer.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Infrastructure.Data
{
    public class IdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<Account> userManager)
        {
            if(!userManager.Users.Any())
            {
                var account = new Account
                {
                    FirstName = "Ruslan",
                    LastName = "Stsefanovich",
                    MiddleName = "Sergeevich",
                    Email = "stefanstrauberg@gmail.com",
                    UserName = "Admin",
                };
                await userManager.CreateAsync(account, "!QAZxsw2");
            }
        }
    }
}