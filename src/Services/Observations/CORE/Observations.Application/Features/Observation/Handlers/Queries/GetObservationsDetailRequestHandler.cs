using AutoMapper;
using MediatR;
using Observations.Application.Contracts.Persistence;
using Observations.Application.DTO;
using Observations.Application.Features.Observation.Requests.Queries;
using Observations.Application.Errors;

namespace Observations.Application.Features.Observation.Handlers.Queries
{
    public class GetObservationsDetailRequestHandler : IRequestHandler<GetObservationDetailRequest, ObservationDto>
    {
        private readonly IObservationsRepository _repository;
        private readonly IMapper _mapper;
        public GetObservationsDetailRequestHandler(
            IObservationsRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ObservationDto> Handle(GetObservationDetailRequest request,
            CancellationToken cancellationToken)
        {
            var obsevation = await _repository.GetAsync(request.id);
            if (obsevation is null)
                throw new ObservationBadRequestException(request.id);
            return _mapper.Map<ObservationDto>(obsevation);
        }
    }
}
