using IdentityServer.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Persistence
{
    public class RepositoryContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) 
            : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
    }
}
