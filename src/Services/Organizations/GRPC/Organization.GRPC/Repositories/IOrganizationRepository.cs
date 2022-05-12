namespace Organization.GRPC.Repositories
{
    public interface IOrganizationRepository : IDisposable
    {
        Task<string> GetUsualNameAsync(string Id);
    }
}
