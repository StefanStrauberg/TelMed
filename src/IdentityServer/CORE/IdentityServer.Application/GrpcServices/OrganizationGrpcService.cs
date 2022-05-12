using Organization.GRPC;

namespace IdentityServer.Application.GrpcServices
{
    public class OrganizationGrpcService
    {
        private readonly OrganizationProtoService.OrganizationProtoServiceClient _organizationProtoServiceClient;
        public OrganizationGrpcService(OrganizationProtoService.OrganizationProtoServiceClient organizationProtoServiceClient)
            => _organizationProtoServiceClient = organizationProtoServiceClient;
        public async Task<string> GetOrgName(string id)
        {
            var orgName = await _organizationProtoServiceClient.GetOrgNameAsync(new GetOrgRequest { Id = id });
            return orgName.Name;
        }
    }
}
