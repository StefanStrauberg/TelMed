namespace Organization.GRPC.Repositories
{
    public interface IOrganizationRepository : IDisposable
    {
        Task<string> GetUsualNameAsync(string Id);
        Task<List<string>> GetOrgNamesByIds(List<string> ids);
    }
}
