namespace Specialization.GRPC.Repositories
{
    public interface ISpecializationRepository : IDisposable
    {
        Task<string> GetAsync(string Id);
        Task<List<string>> GetSpecNamesByIds(List<string> ids);
    }
}
