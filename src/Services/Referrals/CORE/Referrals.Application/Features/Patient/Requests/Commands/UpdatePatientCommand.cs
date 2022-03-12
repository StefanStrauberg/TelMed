using MediatR;
using Referrals.Domain.PatientEntity;

namespace Referrals.Application.Features.Patient.Requests.Commands
{
    public class UpdatePatientCommand : IRequest
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public PatientGender Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
