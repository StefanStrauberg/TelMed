using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Errors;
using Organizations.Application.Features.Organization.Requests.Commands;

namespace Organizations.Application.Features.Organization.Handlers.Commands
{
    public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteOrganizationCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;
        public async Task<Unit> Handle(DeleteOrganizationCommand request, 
            CancellationToken cancellationToken)
        {
            var removeData = await _unitOfWork.Organizations.GetByIdAsync(request.id);
            if (removeData is null)
                throw new OrganizationNotFoundException(request.id.ToString());
            _unitOfWork.Organizations.Remove(removeData);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
