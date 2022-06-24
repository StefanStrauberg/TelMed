using AutoMapper;
using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Features.Specialization.Requests.Commands;

namespace Specializations.Application.Features.Specialization.Handlers.Commands
{
    public class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand>
    {
        private readonly ISpecializationCommandRepository _commandRepository;
        private readonly IMapper _mapper;
        public CreateSpecializationCommandHandler(
            IMapper mapper,
            ISpecializationCommandRepository commandRepository)
        {
            _mapper = mapper;
            _commandRepository = commandRepository;
        }
        public async Task<Unit> Handle(CreateSpecializationCommand request,
            CancellationToken cancellationToken)
        {
            await _commandRepository.Add(_mapper.Map<Domain.Specialization>(request.model));
            return Unit.Value;
        }
    }
}
