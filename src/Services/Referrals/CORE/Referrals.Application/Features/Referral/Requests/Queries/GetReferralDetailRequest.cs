using MediatR;
using Referrals.Application.DTO.ReferralDtos;

namespace Referrals.Application.Features.Referral.Requests.Queries
{
    public record GetReferralDetailRequest(string id) : IRequest<ReferralDto>;
}
