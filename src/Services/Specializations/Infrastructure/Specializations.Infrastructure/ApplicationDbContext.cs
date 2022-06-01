using Microsoft.EntityFrameworkCore;
using Specializations.Domain;

namespace Specializations.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Specialization> Specializations { get; set; }
    }
}
