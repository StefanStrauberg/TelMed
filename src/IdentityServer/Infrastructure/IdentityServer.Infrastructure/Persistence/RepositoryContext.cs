using IdentityServer.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Persistence
{
    public class RepositoryContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
        IdentityUserClaim<Guid>, ApplicationUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) 
            : base(options) 
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder builder)
        {
            var adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Ruslan",
                LastName = "Stsefanovich",
                MiddleName = "Sergeevich",
                Email = "rust@belcmt.by.com",
                NormalizedEmail = "RUST@BELCMT.BY",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                OrganizationId = "6294a0d94f365e01d8c2622d",
                SpecializationId = "6294a0aa4f365e01d8c2619a",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var doctorUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Doctor",
                LastName = "Doctorovich",
                MiddleName = "DOCTOR",
                UserName = "Doctor",
                NormalizedUserName = "DOCTOR",
                OrganizationId = "6294a0d94f365e01d8c2622d",
                SpecializationId = "6294a0aa4f365e01d8c2619a",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var practitionerUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Practitioner",
                LastName = "Practitionerovich",
                MiddleName = "PRACTITIONER",
                UserName = "Practitioner",
                NormalizedUserName = "PRACTITIONER",
                OrganizationId = "6294a0d94f365e01d8c2622d",
                SpecializationId = "6294a0aa4f365e01d8c2619a",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var coordinatorPractitionerUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = "CoordinatorPractitioner",
                LastName = "CoordinatorPractitionerovich",
                MiddleName = "COORDINATORPRACTITIONER",
                UserName = "CoordinatorPractitioner",
                NormalizedUserName = "COORDINATORPRACTITIONER",
                OrganizationId = "6294a0d94f365e01d8c2622d",
                SpecializationId = "6294a0aa4f365e01d8c2619a",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var coordinatorDoctorUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = "CoordinatorDoctor",
                LastName = "CoordinatorDoctorovich",
                MiddleName = "COORDINATORDOCTOR",
                UserName = "CoordinatorDoctor",
                NormalizedUserName = "COORDINATORDOCTOR",
                OrganizationId = "6294a0d94f365e01d8c2622d",
                SpecializationId = "6294a0aa4f365e01d8c2619a",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var developerUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Developer",
                LastName = "Developerovich",
                MiddleName = "DEVELOPER",
                UserName = "Developer",
                NormalizedUserName = "DEVELOPER",
                OrganizationId = "6294a0d94f365e01d8c2622d",
                SpecializationId = "6294a0aa4f365e01d8c2619a",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var password = new PasswordHasher<ApplicationUser>();
            var hashedAdminUser = password.HashPassword(adminUser, "!QAZxsw2");
            var hashedDoctorUser = password.HashPassword(doctorUser, "!QAZxsw2");
            var hashedPractitionerUser = password.HashPassword(practitionerUser, "!QAZxsw2");
            var hashedCoordinatorPractitionerUser = password.HashPassword(coordinatorPractitionerUser, "!QAZxsw2");
            var hashedCoordinatorDoctorUser = password.HashPassword(coordinatorDoctorUser, "!QAZxsw2");
            var hashedDeveloperUser = password.HashPassword(developerUser, "!QAZxsw2");
            adminUser.PasswordHash = hashedAdminUser;
            doctorUser.PasswordHash = hashedDoctorUser;
            practitionerUser.PasswordHash = hashedPractitionerUser;
            coordinatorPractitionerUser.PasswordHash = hashedCoordinatorPractitionerUser;
            coordinatorDoctorUser.PasswordHash = hashedCoordinatorDoctorUser;
            developerUser.PasswordHash = hashedDeveloperUser;

            var doctorRole = new ApplicationRole()
            {
                Id = Guid.NewGuid(),
                Name = "Doctor",
                NormalizedName = "DOCTOR"
            };
            var practitionerRole = new ApplicationRole()
            {
                Id = Guid.NewGuid(),
                Name = "Practitioner",
                NormalizedName = "PRACTITIONER"
            };
            var administratorRole = new ApplicationRole()
            {
                Id = Guid.NewGuid(),
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            };
            var coordinatorPractitionerRole = new ApplicationRole()
            {
                Id = Guid.NewGuid(),
                Name = "CoordinatorPractitioner",
                NormalizedName = "COORDINATORPRACTITIONER"
            };
            var coordinatorDoctorRole = new ApplicationRole()
            {
                Id = Guid.NewGuid(),
                Name = "CoordinatorDoctor",
                NormalizedName = "COORDINATORDOCTOR"
            };
            var developerRole = new ApplicationRole()
            {
                Id = Guid.NewGuid(),
                Name = "Developer",
                NormalizedName = "DEVELOPER"
            };

            builder.Entity<ApplicationRole>().HasData(
                doctorRole, practitionerRole, administratorRole, coordinatorPractitionerRole, coordinatorDoctorRole, developerRole);
            builder.Entity<ApplicationUser>().HasData(
                adminUser, doctorUser, practitionerUser, coordinatorPractitionerUser, coordinatorDoctorUser, developerUser);

            var userRoleAdmin = new ApplicationUserRole()
            {
                RoleId = administratorRole.Id,
                UserId = adminUser.Id
            };
            var userRoleDoctor = new ApplicationUserRole()
            {
                RoleId = doctorRole.Id,
                UserId = doctorUser.Id
            };
            var userRolePractitioner = new ApplicationUserRole()
            {
                RoleId = practitionerRole.Id,
                UserId = practitionerUser.Id
            };
            var userRoleCoordinatorPractitioner = new ApplicationUserRole()
            {
                RoleId = coordinatorPractitionerRole.Id,
                UserId = coordinatorPractitionerUser.Id
            };
            var userRoleCoordinatorDoctor = new ApplicationUserRole()
            {
                RoleId = coordinatorDoctorRole.Id,
                UserId = coordinatorDoctorUser.Id
            };
            var userRoleDeveloper = new ApplicationUserRole()
            {
                RoleId = developerRole.Id,
                UserId = developerUser.Id
            };

            builder.Entity<ApplicationUserRole>().HasData(
                userRoleAdmin, userRoleDoctor, userRolePractitioner, userRoleCoordinatorPractitioner, userRoleCoordinatorDoctor, userRoleDeveloper);
        }

    }
}
