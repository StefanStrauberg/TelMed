namespace Specializations.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ISpecializationRepository Specializations { get; }
        Task<int> Complete();
    }
}
