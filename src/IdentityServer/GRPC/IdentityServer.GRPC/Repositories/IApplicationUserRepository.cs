namespace IdentityServer.GRPC.Repositories
{
    public interface IApplicationUserRepository : IDisposable
    {
        Task<string> GetAccNameAsync(string Id);
    }
}
