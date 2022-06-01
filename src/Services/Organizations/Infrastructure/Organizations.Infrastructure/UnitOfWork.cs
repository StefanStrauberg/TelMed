using Organizations.Application.Contracts.Persistence;

namespace Organizations.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Organizations = new OrganizationRepository(_context);
        }
        public IOrganizationRepository Organizations { get; private set; }

        public async Task<int> Complete()
            => await _context.SaveChangesAsync();

        public async void Dispose()
            => await _context.DisposeAsync();
    }
}
