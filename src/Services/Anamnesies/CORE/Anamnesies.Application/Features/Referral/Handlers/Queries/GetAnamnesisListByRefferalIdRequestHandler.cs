using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.DTO;
using Anamnesies.Application.Features.Referral.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Handlers.Queries
{
    public class GetAnamnesisListByRefferalIdRequestHandler : IRequestHandler<GetAnamnesisListByRefferalIdRequest, IReadOnlyList<AnamnesisDto>>
    {
        private readonly IAnamnesisRepository _repository;
        private readonly IMapper _mapper;
        public GetAnamnesisListByRefferalIdRequestHandler(
            IAnamnesisRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<AnamnesisDto>> Handle(GetAnamnesisListByRefferalIdRequest request, CancellationToken cancellationToken)
            => _mapper.Map<IReadOnlyList<AnamnesisDto>>(await _repository.GetAllAsyncByRefferalId(request.refferalId));
    }
}