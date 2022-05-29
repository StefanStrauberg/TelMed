using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Errors;
using Referrals.Application.Features.Referral.Requests.Commands;
using Referrals.Domain.AnamnesisEntity;

namespace Referrals.Application.Features.Referral.Handlers.Commands
{
    public class UpdateAnamnesisCommandHandler : IRequestHandler<UpdateAnamnesisCommand>
    {
        private readonly IReferralRepository _referralRepository;
        private readonly IMapper _mapper;
        public UpdateAnamnesisCommandHandler(
            IReferralRepository referralRepository,
            IMapper mapper)
        {
            _referralRepository = referralRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateAnamnesisCommand request, CancellationToken cancellationToken)
        {
            if(await _referralRepository.UpdateAnamnesis(_mapper.Map<Anamnesis>(request.model),request.referralId))
                return Unit.Value;
            throw new ReferralBadRequestException(request.referralId);
        }
    }
}