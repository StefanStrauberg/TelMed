using AutoMapper;
using MediatR;
using Purposes.Application.Contracts.Persistence;
using Purposes.Application.Features.Purpouse.Requests.Commands;
using Purposes.Domain;

namespace Purposes.Application.Features.Purpouse.Handlers.Commands
{
    public class CreatePurposeCommandHandler : IRequestHandler<CreatePurposeCommand>
    {
        private readonly IPurposeRepository _repository;
        private readonly IMapper _mapper;
        public CreatePurposeCommandHandler(
            IPurposeRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreatePurposeCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Purpose>(request.model));
            return Unit.Value;
        }
    }
}
