using Specializations.Application.Contracts.Persistence;
using Specializations.Domain;

namespace Specializations.Infrastructure
{
    public class SpecializationRepository : GenericRepository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
