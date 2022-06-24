using Microsoft.Extensions.Configuration;
using Specializations.Application.Contracts.Persistence;
using Specializations.Domain;
using Specializations.Infrastructure.Data;

namespace Specializations.Infrastructure.Repositories.Command
{
    public class SpecializationRepository : SqlConnectionFactory, ISpecializationCommandRepository
    {
        public SpecializationRepository(string connectionString) : base(connectionString)
        {
        }

        public Task<bool> Add(Specialization entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Specialization entity)
        {
            throw new NotImplementedException();
        }
    }
}
