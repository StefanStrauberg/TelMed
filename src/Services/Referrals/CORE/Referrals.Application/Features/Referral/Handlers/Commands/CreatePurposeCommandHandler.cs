using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Errors;
using Referrals.Application.Features.Referral.Requests.Commands;
using Referrals.Domain.PurposeEntity;

namespace Referrals.Application.Features.Referral.Handlers.Commands
{
    public class CreatePurposeCommandHandler : IRequestHandler<CreatePurposeCommand>
    {
        private readonly IReferralRepository _referralRepository;
        private readonly IMapper _mapper;
        public CreatePurposeCommandHandler(
            IReferralRepository referralRepository,
            IMapper mapper)
        {
            _referralRepository = referralRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreatePurposeCommand request, CancellationToken cancellationToken)
        {
            if(await _referralRepository.CreatePurpose(_mapper.Map<Purpose>(request.model), request.referralId))
                return Unit.Value;
            throw new ReferralBadRequestException(request.referralId);
        }
    }
}