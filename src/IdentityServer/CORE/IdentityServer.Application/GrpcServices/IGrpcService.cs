namespace IdentityServer.Application.GrpcServices
{
    public interface IGrpcService
    {
        Task<string> GetSpecName(string id);
        Task<List<string>> GetSpecNamesByListIds(List<string> ids);
        Task<string> GetOrgName(string id);
        Task<List<string>> GetOrgNamesByListIds(List<string> ids);
    }
}
