using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Errors;
using Referrals.Application.Features.Referral.Requests.Commands;
using Referrals.Domain.PurposeEntity;

namespace Referrals.Application.Features.Referral.Handlers.Commands
{
    public class UpdatePurposeCommandHandler : IRequestHandler<UpdatePurposeCommand>
    {
        private readonly IReferralRepository _referralRepository;
        private readonly IMapper _mapper;
        public UpdatePurposeCommandHandler(
            IReferralRepository referralRepository,
            IMapper mapper)
        {
            _referralRepository = referralRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdatePurposeCommand request, CancellationToken cancellationToken)
        {
            if(await _referralRepository.UpdatePurpose(_mapper.Map<Purpose>(request.model),request.referralId))
                return Unit.Value;
            throw new ReferralBadRequestException(request.referralId);
        }
    }
}