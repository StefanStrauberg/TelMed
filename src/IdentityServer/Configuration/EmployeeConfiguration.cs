using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
                var user = new User
                {
                    FirstName = "Ruslan",
                    LastName = "Stsefanovich",
                    MiddleName = "Sergeevich",
                    Email = "stefanstrauberg@gmail.com",
                    NormalizedEmail = "STEFANSTRAUBERG@GMAIL.COM",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    EmailConfirmed = true,
                    PhoneNumber = "+375297772226665",
                    PhoneNumberConfirmed = true
                };
            builder.HasData(
                user
            );
            var password = new PasswordHasher<User>();
            var hashed = password.HashPassword(user, "!QAZxsw2");
            user.PasswordHash = hashed;
        }
    }
}