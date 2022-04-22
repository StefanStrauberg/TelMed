using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.Features.Referral.Requests.Commands;
using Anamnesies.Domain;
using AutoMapper;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Handlers.Commands
{
    public class CreateAnamnesisCommandHandler : IRequestHandler<CreateAnamnesisCommand>
    {
        private readonly IAnamnesisRepository _repository;
        private readonly IMapper _mapper;
        public CreateAnamnesisCommandHandler(
            IAnamnesisRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateAnamnesisCommand request,
            CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Anamnesis>(request.model));
            return Unit.Value;
        }
    }
}
