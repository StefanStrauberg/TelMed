using AutoMapper;
using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Features.Specialization.Requests.Commands;

namespace Specializations.Application.Features.Specialization.Handlers.Commands
{
    public class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand>
    {
        private readonly ISpecializationRepository _repository;
        private readonly IMapper _mapper;
        public CreateSpecializationCommandHandler(
            ISpecializationRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateSpecializationCommand request,
            CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Domain.Specialization>(request.model));
            return Unit.Value;
        }
    }
}
