﻿using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.DTO;
using Referrals.Application.Features.Referral.Requests.Queries;

namespace Referrals.Application.Features.Referral.Handlers.Queries
{
    public class GetReferralListRequestHandler : IRequestHandler<GetReferralListRequest, IReadOnlyList<ReferralDto>>
    {
        private readonly IReferralRepository _repository;
        private readonly IMapper _mapper;
        public GetReferralListRequestHandler(IReferralRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<ReferralDto>> Handle(GetReferralListRequest request, CancellationToken cancellationToken)
        {
            var referrals = await _repository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<ReferralDto>>(referrals);
        }
    }
}