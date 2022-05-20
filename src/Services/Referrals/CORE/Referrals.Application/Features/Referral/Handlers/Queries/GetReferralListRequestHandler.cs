using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.DTO;
using Referrals.Application.Features.Referral.Requests.Queries;
using Referrals.Application.Specs;

namespace Referrals.Application.Features.Referral.Handlers.Queries
{
    public class GetReferralListRequestHandler : IRequestHandler<GetReferralListRequest, PagedList<ReferralDto>>
    {
        private readonly IReferralRepository _repository;
        private readonly IMapper _mapper;
        public GetReferralListRequestHandler(
            IReferralRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<ReferralDto>> Handle(GetReferralListRequest request,
            CancellationToken cancellationToken)
            => new PagedList<ReferralDto>(
                _mapper.Map<List<ReferralDto>>(await _repository.GetAllAsync(request.querySpecParams, request.AccountId)),
                await _repository.CountAsync(request.querySpecParams, request.AccountId),
                request.querySpecParams.PageIndex,
                request.querySpecParams.PageSize);
    }
}
