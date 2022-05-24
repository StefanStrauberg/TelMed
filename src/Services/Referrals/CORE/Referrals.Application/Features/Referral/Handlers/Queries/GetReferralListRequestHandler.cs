using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.DTO;
using Referrals.Application.Features.Referral.Requests.Queries;
using Referrals.Application.GrpcServices;
using Referrals.Application.Specs;

namespace Referrals.Application.Features.Referral.Handlers.Queries
{
    public class GetReferralListRequestHandler : IRequestHandler<GetReferralListRequest, PagedList<ReferralDto>>
    {
        private readonly IReferralRepository _repository;
        private readonly IMapper _mapper;
        private readonly IGrpcService _grpcService;
        public GetReferralListRequestHandler(
            IReferralRepository repository,
            IMapper mapper,
            IGrpcService grpcService)
        {
            _repository = repository;
            _mapper = mapper;
            _grpcService = grpcService;
        }
        public async Task<PagedList<ReferralDto>> Handle(GetReferralListRequest request,
            CancellationToken cancellationToken)
        {
            var data = _mapper.Map<List<ReferralDto>>(await _repository.GetAllAsync(request.querySpecParams, request.AccountId));
            await Parallel.ForEachAsync(data, async (x, CancellationToken) =>
            {
                x.AuthorId = await _grpcService.GetAccName(x.AuthorId);
            });
            return new PagedList<ReferralDto>(
                    data,
                    await _repository.CountAsync(request.querySpecParams, request.AccountId),
                    request.querySpecParams.PageIndex,
                    request.querySpecParams.PageSize);
        } 
    }
}
