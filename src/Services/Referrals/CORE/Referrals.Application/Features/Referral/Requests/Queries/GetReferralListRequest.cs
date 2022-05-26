using MediatR;
using Referrals.Application.DTO;

namespace Referrals.Application.Features.Referral.Requests.Queries
{
    public record GetReferralListRequest(string AccountId) : IRequest<List<ReferralDto>>;
}
