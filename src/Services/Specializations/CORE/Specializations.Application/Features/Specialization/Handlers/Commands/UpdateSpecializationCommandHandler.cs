using AutoMapper;
using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.DTO;
using Specializations.Application.Errors;
using Specializations.Application.Features.Specialization.Requests.Commands;

namespace Specializations.Application.Features.Specialization.Handlers.Commands
{
    public class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand>
    {
        private readonly ISpecializationCommandRepository _commandRepository;
        private readonly IMapper _mapper;
        public UpdateSpecializationCommandHandler(
            IMapper mapper,
            ISpecializationCommandRepository commandRepository)
        {
            _mapper = mapper;
            _commandRepository = commandRepository;
        }
        public async Task<Unit> Handle(UpdateSpecializationCommand request,
            CancellationToken cancellationToken)
        {
            var updateResult = await _commandRepository.Update(_mapper.Map<Domain.Specialization>(request.model));
            if (updateResult is false)
                throw new SpecializationNotFoundException(request.id.ToString());
            return Unit.Value;
        }
    }
}
