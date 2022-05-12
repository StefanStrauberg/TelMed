using Grpc.Core;
using Organization.GRPC.Repositories;

namespace Organization.GRPC.Services
{
    public class OrganizationService : OrganizationProtoService.OrganizationProtoServiceBase
    {
        private readonly IOrganizationRepository _repository;
        public OrganizationService(IOrganizationRepository repository)
            => _repository = repository;
        public override async Task<OrgName> GetOrgName(GetOrgRequest request, ServerCallContext context)
            => new OrgName { Name = await _repository.GetUsualNameAsync(request.Id) };
    }
}
