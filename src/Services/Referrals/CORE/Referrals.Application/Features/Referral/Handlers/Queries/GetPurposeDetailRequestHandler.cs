using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.DTO.PurposeDtos;
using Referrals.Application.Features.Referral.Requests.Queries;

namespace Referrals.Application.Features.Referral.Handlers.Queries
{
    public class GetPurposeDetailRequestHandler : IRequestHandler<GetPurposeDetailRequest, PurposeDto>
    {
        private readonly IReferralRepository _referralRepository;
        private readonly IMapper _mapper;
        public GetPurposeDetailRequestHandler(
            IReferralRepository referralRepository,
            IMapper mapper)
        {
            _referralRepository = referralRepository;
            _mapper = mapper;
        }

        public async Task<PurposeDto> Handle(GetPurposeDetailRequest request, CancellationToken cancellationToken)
            => _mapper.Map<PurposeDto>(await _referralRepository.GetPurposeByReferralIdAndPurposeGroupId(request.referralId, request.purposeGroupId));
    }
}