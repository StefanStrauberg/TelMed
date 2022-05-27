using AutoMapper;
using MediatR;
using Purposes.Application.Contracts.Persistence;
using Purposes.Application.DTO;
using Purposes.Application.Features.Purpouse.Requests.Queries;

namespace Purposes.Application.Features.Purpouse.Handlers.Queries
{
    public class GetPurposeListRequestHandler : IRequestHandler<GetPurposeListRequest, IReadOnlyList<PurposeDto>>
    {
        private readonly IPurposeRepository _repository;
        private readonly IMapper _mapper;
        public GetPurposeListRequestHandler(
            IPurposeRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<PurposeDto>> Handle(GetPurposeListRequest request, CancellationToken cancellationToken)
            => _mapper.Map<IReadOnlyList<PurposeDto>>(await _repository.GetAllAsync());
    }
}
