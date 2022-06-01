using Organizations.Application.Contracts.Persistence;
using Organizations.Domain;

namespace Organizations.Infrastructure
{
    public class OrganizationRepository : GenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
