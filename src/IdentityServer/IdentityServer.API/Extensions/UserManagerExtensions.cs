using System.Security.Claims;
using IdentityServer.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<Account> FindByEmailFromClaimsAsync(
            this UserManager<Account> input,
            ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);
            return await input.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}