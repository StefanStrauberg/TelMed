using MediatR;

namespace ReferralRequests.Application.Features.ReferralRequest.Requests.Commands
{
    public class CreateReferralRequestCommand : IRequest<string>
    {
        public string Diagnosis { get; set; }
        public string ReferralId { get; private set; }
        public string SpecializationId { get; private set; }
        public string OrganizationId { get; private set; }
        public Guid AccountId { get; private set; }
        //public MedicalAttention MedicalAttention { get; set; }
    }
}
