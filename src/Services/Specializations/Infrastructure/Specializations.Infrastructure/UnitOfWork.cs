using Specializations.Application.Contracts.Persistence;

namespace Specializations.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Specializations = new SpecializationRepository(_context);
        }
        public ISpecializationRepository Specializations { get; private set; }

        public async Task<int> Complete()
            => await _context.SaveChangesAsync();

        public async void Dispose()
            => await _context.DisposeAsync();
    }
}
