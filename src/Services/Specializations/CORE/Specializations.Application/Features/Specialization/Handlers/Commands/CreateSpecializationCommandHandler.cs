using AutoMapper;
using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Features.Specialization.Requests.Commands;

namespace Specializations.Application.Features.Specialization.Handlers.Commands
{
    public class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateSpecializationCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateSpecializationCommand request,
            CancellationToken cancellationToken)
        {
            await _unitOfWork.Specializations.Add(_mapper.Map<Domain.Specialization>(request.model));
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
