using MediatR;
using Referrals.Application.DTO.ReferralDtos;

namespace Referrals.Application.Features.Referral.Requests.Queries
{
    public record GetReferralListRequest(string AccountId) : IRequest<List<ReferralDto>>;
}
