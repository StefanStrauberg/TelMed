using MediatR;
using Referrals.Application.DTO;
using Referrals.Application.Specs;

namespace Referrals.Application.Features.Referral.Requests.Queries
{
    public record GetReferralListRequest(QuerySpecParams querySpecParams, string AccountId) : IRequest<PagedList<ReferralDto>>;
}
