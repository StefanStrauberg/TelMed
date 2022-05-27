using MediatR;
using Purposes.Application.Contracts.Persistence;
using Purposes.Application.Errors;
using Purposes.Application.Features.Purpouse.Requests.Commands;

namespace Purposes.Application.Features.Purpouse.Handlers.Commands
{
    public class DeletePurposeCommandHandler : IRequestHandler<DeletePurposeCommand>
    {
        private readonly IPurposeRepository _repository;
        public DeletePurposeCommandHandler(IPurposeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeletePurposeCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.DeleteAsync(request.id))
                return Unit.Value;
            throw new PurposeBadRequestException(request.id);
        }
    }
}
