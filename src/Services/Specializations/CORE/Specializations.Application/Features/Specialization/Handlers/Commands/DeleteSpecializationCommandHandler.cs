using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Errors;
using Specializations.Application.Features.Specialization.Requests.Commands;

namespace Specializations.Application.Features.Specialization.Handlers.Commands
{
    public class DeleteSpecializationCommandHandler : IRequestHandler<DeleteSpecializationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteSpecializationCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;
        public async Task<Unit> Handle(DeleteSpecializationCommand request,
            CancellationToken cancellationToken)
        {
            var removeData = await _unitOfWork.Specializations.GetByIdAsync(request.id);
            if (removeData is null)
                throw new SpecializationNotFoundException(request.id.ToString());
            _unitOfWork.Specializations.Remove(removeData);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
