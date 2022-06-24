using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Errors;
using Specializations.Application.Features.Specialization.Requests.Commands;

namespace Specializations.Application.Features.Specialization.Handlers.Commands
{
    public class DeleteSpecializationCommandHandler : IRequestHandler<DeleteSpecializationCommand>
    {
        private readonly ISpecializationCommandRepository _commandRepository;
        public DeleteSpecializationCommandHandler(ISpecializationCommandRepository commandRepository)
            => _commandRepository = commandRepository;
        public async Task<Unit> Handle(DeleteSpecializationCommand request,
            CancellationToken cancellationToken)
        {
            var removeResult = await _commandRepository.Remove(request.id);
            if (removeResult is false)
                throw new SpecializationNotFoundException(request.id.ToString());
            return Unit.Value;
        }
    }
}
