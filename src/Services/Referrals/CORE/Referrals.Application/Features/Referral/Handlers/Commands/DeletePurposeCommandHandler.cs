using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Errors;
using Referrals.Application.Features.Referral.Requests.Commands;

namespace Referrals.Application.Features.Referral.Handlers.Commands
{
    public class DeletePurposeCommandHandler : IRequestHandler<DeletePurposeCommand>
    {
        private readonly IReferralRepository _referralRepository;
        private readonly IMapper _mapper;
        public DeletePurposeCommandHandler(
            IReferralRepository referralRepository,
            IMapper mapper)
        {
            _referralRepository = referralRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeletePurposeCommand request, CancellationToken cancellationToken)
        {
            if(await _referralRepository.RemovePurpose(request.referralId, request.purposeGroupId))
                return Unit.Value;
            throw new ReferralBadRequestException(request.referralId);
        }
    }
}