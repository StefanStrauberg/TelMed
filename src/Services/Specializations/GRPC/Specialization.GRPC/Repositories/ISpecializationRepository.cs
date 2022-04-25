namespace Specialization.GRPC.Repositories
{
    public interface ISpecializationRepository : IDisposable
    {
        Task<string> GetAsync(string Id);
    }
}
