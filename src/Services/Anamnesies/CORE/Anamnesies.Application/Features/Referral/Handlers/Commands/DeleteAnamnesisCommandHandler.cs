using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.Features.Referral.Requests.Commands;
using Anamnesies.Domain.Exceptions;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Handlers.Commands
{
    public class DeleteAnamnesisCommandHandler : IRequestHandler<DeleteAnamnesisCommand>
    {
        private readonly IAnamnesisRepository _repository;
        public DeleteAnamnesisCommandHandler(IAnamnesisRepository repository)
            => _repository = repository;
        public async Task<Unit> Handle(DeleteAnamnesisCommand request,
            CancellationToken cancellationToken)
        {
            if (await _repository.DeleteAsync(request.id))
                return Unit.Value;
            throw new AnamnesisBadRequestException(request.id);
        }
    }
}
