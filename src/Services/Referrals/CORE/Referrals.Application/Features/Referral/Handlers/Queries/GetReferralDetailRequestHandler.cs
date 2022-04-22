using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.DTO;
using Referrals.Application.Features.Referral.Requests.Queries;
using Referrals.Domain.Exceptions;

namespace Referrals.Application.Features.Referral.Handlers.Queries
{
    public class GetReferralDetailRequestHandler : IRequestHandler<GetReferralDetailRequest, ReferralDto>
    {
        private readonly IReferralRepository _repository;
        private readonly IMapper _mapper;
        public GetReferralDetailRequestHandler(
            IReferralRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ReferralDto> Handle(GetReferralDetailRequest request,
            CancellationToken cancellationToken)
        {
            var referral = await _repository.GetAsync(request.id);
            if (referral is null)
                throw new ReferralBadRequestException(request.id);
            return _mapper.Map<ReferralDto>(referral);
        }
    }
}
