using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.DTO;
using Anamnesies.Application.Features.Referral.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Handlers.Queries
{
    public class GetAnamnesisListRequestHandler : IRequestHandler<GetAnamnesisListRequest, IReadOnlyList<AnamnesisDto>>
    {
        private readonly IAnamnesisRepository _repository;
        private readonly IMapper _mapper;
        public GetAnamnesisListRequestHandler(
            IAnamnesisRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<AnamnesisDto>> Handle(GetAnamnesisListRequest request,
            CancellationToken cancellationToken)
            => _mapper.Map<IReadOnlyList<AnamnesisDto>>(await _repository.GetAllAsync());
    }
}
