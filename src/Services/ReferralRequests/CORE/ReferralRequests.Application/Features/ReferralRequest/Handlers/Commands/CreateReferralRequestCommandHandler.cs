using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ReferralRequests.Application.Contracts.Persistence;
using ReferralRequests.Application.Features.ReferralRequest.Requests.Commands;

namespace ReferralRequests.Application.Features.ReferralRequest.Handlers.Commands
{
    public class CreateReferralRequestCommandHandler : IRequestHandler<CreateReferralRequestCommand, string>
    {
        private readonly IReferralRequestRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateReferralRequestCommandHandler> _logger;
        public CreateReferralRequestCommandHandler(
            IReferralRequestRepository repository,
            IMapper mapper,
            ILogger<CreateReferralRequestCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<string> Handle(CreateReferralRequestCommand request, CancellationToken cancellationToken)
        {
            var referralEntity = _mapper.Map<Domain.ReferralRequest>(request);
            await _repository.CreateAsync(referralEntity);
            _logger.LogInformation($"ReferralRequest {referralEntity.Id} in Referral {referralEntity.ReferralId} is successfully created.");
            return referralEntity.Id;
        }
    }
}
