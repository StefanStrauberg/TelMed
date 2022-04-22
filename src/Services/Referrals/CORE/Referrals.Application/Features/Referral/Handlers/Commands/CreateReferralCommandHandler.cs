using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Features.Referral.Requests.Commands;

namespace Referrals.Application.Features.Referral.Handlers.Commands
{
    public class CreateReferralCommandHandler : IRequestHandler<CreateReferralCommand>
    {
        private readonly IReferralRepository _repository;
        private readonly IMapper _mapper;
        public CreateReferralCommandHandler(
            IReferralRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateReferralCommand request,
            CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Domain.Referral>(request.model));
            return Unit.Value;
        }
    }
}
