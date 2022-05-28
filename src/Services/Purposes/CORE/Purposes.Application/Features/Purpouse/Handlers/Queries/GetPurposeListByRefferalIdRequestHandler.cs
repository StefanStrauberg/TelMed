using AutoMapper;
using MediatR;
using Purposes.Application.Contracts.Persistence;
using Purposes.Application.DTO;
using Purposes.Application.Features.Purpouse.Requests.Queries;

namespace Purposes.Application.Features.Purpouse.Handlers.Queries
{
    public class GetPurposeListByRefferalIdRequestHandler : IRequestHandler<GetPurposeListByRefferalIdRequest, IReadOnlyList<PurposeDto>>
    {
        private readonly IPurposeRepository _purposeRepository;
        private readonly IMapper _mapper;
        public GetPurposeListByRefferalIdRequestHandler(
            IPurposeRepository purposeRepository,
            IMapper mapper)
        {
            _purposeRepository = purposeRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<PurposeDto>> Handle(GetPurposeListByRefferalIdRequest request, CancellationToken cancellationToken)
            => _mapper.Map<IReadOnlyList<PurposeDto>>(await _purposeRepository.GetAllAsyncByRefferalId(request.id));
    }
}