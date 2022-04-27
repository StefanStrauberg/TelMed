using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Doctor",
                    NormalizedName = "DOCTOR"
                },
                new IdentityRole
                {
                    Name = "Practitioner",
                    NormalizedName = "PRACTITIONER"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "CoordinatorPractitioner",
                    NormalizedName = "COORDINATORPRACTITIONER"
                },
                new IdentityRole
                {
                    Name = "CoordinatorDoctor",
                    NormalizedName = "COORDINATORDOCTOR"
                },
                new IdentityRole
                {
                    Name = "Developer",
                    NormalizedName = "DEVELOPER"
                }
            );
        }
    }
}
