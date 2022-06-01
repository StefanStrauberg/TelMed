using Microsoft.EntityFrameworkCore;
using Organizations.Domain;

namespace Organizations.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Organization> Organizations { get; set; }
    }
}
