using MediatR;
using Microsoft.Extensions.Logging;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Features.Specialization.Requests.Commands;
using Specializations.Domain.Exceptions;

namespace Specializations.Application.Features.Specialization.Handlers.Commands
{
    public class DeleteSpecializationCommandHandler : IRequestHandler<DeleteSpecializationCommand>
    {
        private readonly ISpecializationRepository _repository;
        public DeleteSpecializationCommandHandler(ISpecializationRepository repository)
            => _repository = repository;
        public async Task<Unit> Handle(DeleteSpecializationCommand request,
            CancellationToken cancellationToken)
        {
            if(await _repository.DeleteAsync(request.id))
                return Unit.Value;
            throw new SpecializationBadRequestException(request.id);
        }
    }
}
