﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Exceptions;
using Referrals.Application.Features.Referral.Requests.Commands;

namespace Referrals.Application.Features.Referral.Handlers.Commands
{
    public class UpdateReferralCommandHandler : IRequestHandler<UpdateReferralCommand>
    {
        private readonly IReferralRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateReferralCommandHandler> _logger;
        public UpdateReferralCommandHandler(
            IReferralRepository repository,
            IMapper mapper,
            ILogger<UpdateReferralCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateReferralCommand request, CancellationToken cancellationToken)
        {
            var referralToUpdate = _mapper.Map<Domain.Referral>(request);
            if (!await _repository.UpdateAsync(referralToUpdate))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation("");
            return Unit.Value;
        }
    }
}
