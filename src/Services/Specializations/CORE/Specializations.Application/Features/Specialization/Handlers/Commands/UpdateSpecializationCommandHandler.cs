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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateSpecializationCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateSpecializationCommand request,
            CancellationToken cancellationToken)
        {
            var specializationToUpdate = await _unitOfWork.Specializations.GetByIdAsync(request.id);
            if (specializationToUpdate is null)
                throw new SpecializationNotFoundException(request.id.ToString());
            _mapper.Map(request.model, specializationToUpdate, typeof(CreateSpecializationDto), typeof(Domain.Specialization));
            _unitOfWork.Specializations.Update(specializationToUpdate);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
