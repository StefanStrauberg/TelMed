using MediatR;
using Referrals.Application.DTO;

namespace Referrals.Application.Features.Referral.Requests.Queries
{
    public class GetReferralListRequest : IRequest<IReadOnlyList<Domain.Referral>>
    {
    }
}
