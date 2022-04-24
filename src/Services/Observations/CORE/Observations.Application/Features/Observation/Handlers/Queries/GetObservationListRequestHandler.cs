using AutoMapper;
using MediatR;
using Observations.Application.Contracts.Persistence;
using Observations.Application.DTO;
using Observations.Application.Features.Observation.Requests.Queries;

namespace Observations.Application.Features.Observation.Handlers.Queries
{
    public class GetObservationListRequestHandler : IRequestHandler<GetObservationListRequest, IReadOnlyList<ObservationDto>>
    {
        private readonly IObservationsRepository _repository;
        private readonly IMapper _mapper;
        public GetObservationListRequestHandler(
            IObservationsRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<ObservationDto>> Handle(GetObservationListRequest request,
            CancellationToken cancellationToken)
            => _mapper.Map<IReadOnlyList<ObservationDto>>(await _repository.GetAllAsync(request.querySpecParams));
    }
}
