using Referrals.Domain.PatientEntity;

namespace Referrals.Application.Contracts.Persistence
{
    public interface IPatientRepository
    {
        Task<bool> UpdateAsync(Patient entity);
    }
}
