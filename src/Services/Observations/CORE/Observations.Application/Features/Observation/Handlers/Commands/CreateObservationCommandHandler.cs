using AutoMapper;
using MediatR;
using Observations.Application.Contracts.Persistence;
using Observations.Application.Features.Observation.Requests.Commands;

namespace Observations.Application.Features.Observation.Handlers.Commands
{
    public class CreateObservationCommandHandler : IRequestHandler<CreateObservationCommand>
    {
        private readonly IObservationsRepository _repository;
        private readonly IMapper _mapper;
        public CreateObservationCommandHandler(
            IObservationsRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateObservationCommand request,
            CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Domain.Observation>(request.model));
            return Unit.Value;
        }
    }
}
