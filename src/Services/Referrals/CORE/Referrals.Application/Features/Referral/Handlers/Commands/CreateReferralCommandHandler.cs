using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Features.Referral.Requests.Commands;

namespace Referrals.Application.Features.Referral.Handlers.Commands
{
    public class CreateReferralCommandHandler : IRequestHandler<CreateReferralCommand, string>
    {
        private readonly IReferralRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateReferralCommandHandler> _logger;
        public CreateReferralCommandHandler(
            IReferralRepository repository,
            IMapper mapper,
            ILogger<CreateReferralCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<string> Handle(CreateReferralCommand request, CancellationToken cancellationToken)
        {
            var referralEntity = _mapper.Map<Domain.Referral>(request);
            await _repository.CreateAsync(referralEntity);
            _logger.LogInformation($"Referral {referralEntity.Id} is successfully created.");
            return referralEntity.Id;
        }
    }
}
