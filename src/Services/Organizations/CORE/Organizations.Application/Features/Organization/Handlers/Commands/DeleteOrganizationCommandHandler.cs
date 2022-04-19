using MediatR;
using Microsoft.Extensions.Logging;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Features.Organization.Requests.Commands;
using Organizations.Domain.Exceptions;

namespace Organizations.Application.Features.Organization.Handlers.Commands
{
    public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand>
    {
        private readonly IOrganizationRepository _repository;
        public DeleteOrganizationCommandHandler(IOrganizationRepository repository) => _repository = repository;
        public async Task<Unit> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            if(await _repository.DeleteAsync(request.Id))
                return Unit.Value;
            throw new OrganizationNotFoundException(request.Id);
        }
    }
}
