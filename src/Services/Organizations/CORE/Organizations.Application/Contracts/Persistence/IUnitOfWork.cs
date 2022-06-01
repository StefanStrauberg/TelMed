namespace Organizations.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IOrganizationRepository Organizations { get; }
        Task<int> Complete();
    }
}
