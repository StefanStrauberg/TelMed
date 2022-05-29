using MediatR;
using Referrals.Application.DTO.PurposeDtos;

namespace Referrals.Application.Features.Referral.Requests.Queries
{
    public record GetPurposeDetailRequest(string referralId, int purposeGroupId) : IRequest<PurposeDto>;
}