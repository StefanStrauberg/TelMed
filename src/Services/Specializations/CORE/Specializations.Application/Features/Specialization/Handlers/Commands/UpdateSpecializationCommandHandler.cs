using AutoMapper;
using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Features.Specialization.Requests.Commands;
using Specializations.Domain.Exceptions;

namespace Specializations.Application.Features.Specialization.Handlers.Commands
{
    public class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand>
    {
        private readonly ISpecializationRepository _repository;
        private readonly IMapper _mapper;
        public UpdateSpecializationCommandHandler(
            ISpecializationRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateSpecializationCommand request,
            CancellationToken cancellationToken)
        {
            if (await _repository.UpdateAsync(_mapper.Map<Domain.Specialization>(request.model), request.id))
                return Unit.Value;
            throw new SpecializationBadRequestException(request.id);
        }
    }
}
