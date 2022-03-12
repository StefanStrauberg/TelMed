using MediatR;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public class CreateReferralCommand : IRequest<string>
    {
        public Domain.PatientEntity.Patient Patient { get; set; }
        public Guid AuthorId { get; set; }
    }
}
