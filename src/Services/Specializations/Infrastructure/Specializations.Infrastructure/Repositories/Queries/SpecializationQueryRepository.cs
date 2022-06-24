using BaseDomain.Specifications;
using Specializations.Application.Contracts.Persistence;
using Specializations.Domain;
using Specializations.Infrastructure.Data;

namespace Specializations.Infrastructure.Repositories.Queries
{
    public class SpecializationQueryRepository : SqlConnectionFactory, ISpecializationQueryRepository
    {
        public SpecializationQueryRepository(string connectionString) : base(connectionString)
        {
        }

        public Task<int> CountAsync(ISpecification<Specialization> specification)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Specialization>> FindWithSpecificationAsync(ISpecification<Specialization> specification = null)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Specialization>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Specialization> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
