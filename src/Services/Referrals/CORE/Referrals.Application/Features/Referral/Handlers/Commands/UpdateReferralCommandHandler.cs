using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Features.Referral.Requests.Commands;
using Referrals.Application.Errors;

namespace Referrals.Application.Features.Referral.Handlers.Commands
{
    public class UpdateReferralCommandHandler : IRequestHandler<UpdateReferralCommand>
    {
        private readonly IReferralRepository _repository;
        private readonly IMapper _mapper;
        public UpdateReferralCommandHandler(
            IReferralRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateReferralCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.UpdateAsync(_mapper.Map<Domain.ReferralEntity.Referral>(request.model), request.referralId))
                return Unit.Value;
            throw new ReferralBadRequestException(request.referralId);
        }
    }
}
