using MediatR;
using Referrals.Application.DTO.AnamnesisDtos;

namespace Referrals.Application.Features.Referral.Requests.Queries
{
    public record GetAnamnesisDetailRequest(string referralId, int anamnesisCategoryId) : IRequest<AnamnesisDto>;
}