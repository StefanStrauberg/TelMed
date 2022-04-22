using AutoMapper;
using MediatR;
using Observations.Application.Contracts.Persistence;
using Observations.Application.Features.Observation.Requests.Commands;
using Observations.Domain.Exceptions;

namespace Observations.Application.Features.Observation.Handlers.Commands
{
    public class UpdateObservationCommandHandler : IRequestHandler<UpdateObservationCommand>
    {
        private readonly IObservationsRepository _repository;
        private readonly IMapper _mapper;
        public UpdateObservationCommandHandler(
            IObservationsRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateObservationCommand request,
            CancellationToken cancellationToken)
        {
            if (await _repository.UpdateAsync(_mapper.Map<Domain.Observation>(request.model), request.id))
                return Unit.Value;
            throw new ObservationBadRequestException(request.id);
        }
    }
}
