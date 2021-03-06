using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Errors;
using Referrals.Application.Features.Referral.Requests.Commands;

namespace Referrals.Application.Features.Referral.Handlers.Commands
{
    public class DeleteAnamnesisCommandHandler : IRequestHandler<DeleteAnamnesisCommand>
    {
        private readonly IReferralRepository _referralRepository;
        private readonly IMapper _mapper;
        public DeleteAnamnesisCommandHandler(
            IReferralRepository referralRepository,
            IMapper mapper)
        {
            _referralRepository = referralRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteAnamnesisCommand request, CancellationToken cancellationToken)
        {
            if(await _referralRepository.RemoveAnamnesis(request.referralId, request.anamnesisCategoryId))
                return Unit.Value;
            throw new ReferralBadRequestException(request.referralId);
        }
    }
}