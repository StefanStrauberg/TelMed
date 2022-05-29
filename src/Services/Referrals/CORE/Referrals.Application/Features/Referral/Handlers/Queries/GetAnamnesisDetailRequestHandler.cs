using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.DTO.AnamnesisDtos;
using Referrals.Application.Features.Referral.Requests.Queries;

namespace Referrals.Application.Features.Referral.Handlers.Queries
{
    public class GetAnamnesisDetailRequestHandler : IRequestHandler<GetAnamnesisDetailRequest, AnamnesisDto>
    {
        private readonly IReferralRepository _referralRepository;
        private readonly IMapper _mapper;
        public GetAnamnesisDetailRequestHandler(
            IReferralRepository referralRepository,
            IMapper mapper)
        {
            _referralRepository = referralRepository;
            _mapper = mapper;
        }
        public async Task<AnamnesisDto> Handle(GetAnamnesisDetailRequest request, CancellationToken cancellationToken)
            => _mapper.Map<AnamnesisDto>(await _referralRepository.GetAnamnesisByReferralIdAndAnamnesisCategoryId(request.referralId, request.anamnesisCategoryId));
    }
}