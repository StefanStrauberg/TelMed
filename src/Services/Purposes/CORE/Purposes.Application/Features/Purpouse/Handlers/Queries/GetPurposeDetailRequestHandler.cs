using AutoMapper;
using MediatR;
using Purposes.Application.Contracts.Persistence;
using Purposes.Application.DTO;
using Purposes.Application.Errors;
using Purposes.Application.Features.Purpouse.Requests.Queries;

namespace Purposes.Application.Features.Purpouse.Handlers.Queries
{
    public class GetPurposeDetailRequestHandler : IRequestHandler<GetPurposeDetailRequest, PurposeDto>
    {
        private readonly IPurposeRepository _repository;
        private readonly IMapper _mapper;
        public GetPurposeDetailRequestHandler(
            IPurposeRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PurposeDto> Handle(GetPurposeDetailRequest request, CancellationToken cancellationToken)
        {
            var purpouse = await _repository.GetAsync(request.id);
            if (purpouse is null)
                throw new PurposeBadRequestException(request.id);
            return _mapper.Map<PurposeDto>(purpouse);
        }
    }
}
