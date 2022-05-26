using AutoMapper;
using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.DTO;
using Referrals.Application.Features.Referral.Requests.Queries;
using Referrals.Application.GrpcServices;

namespace Referrals.Application.Features.Referral.Handlers.Queries
{
    public class GetReferralListRequestHandler : IRequestHandler<GetReferralListRequest, List<ReferralDto>>
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
        public async Task<List<ReferralDto>> Handle(GetReferralListRequest request,
            CancellationToken cancellationToken)
        {
            var data = _mapper.Map<List<ReferralDto>>(await _repository.GetAllAsync(request.AccountId));
            await Parallel.ForEachAsync(data, async (x, CancellationToken) =>
            {
                x.AuthorId = await _grpcService.GetAccName(x.AuthorId);
            });
            return data;
        } 
    }
}
