using AutoMapper;
using MediatR;
using Purposes.Application.Contracts.Persistence;
using Purposes.Application.Errors;
using Purposes.Application.Features.Purpouse.Requests.Commands;
using Purposes.Domain;

namespace Purposes.Application.Features.Purpouse.Handlers.Commands
{
    public class UpdatePurposeCommandHandler : IRequestHandler<UpdatePurposeCommand>
    {
        private readonly IPurposeRepository _repository;
        private readonly IMapper _mapper;
        public UpdatePurposeCommandHandler(
            IPurposeRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdatePurposeCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.UpdateAsync(_mapper.Map<Purpose>(request.model), request.id))
                return Unit.Value;
            throw new PurposeBadRequestException(request.id);
        }
    }
}
