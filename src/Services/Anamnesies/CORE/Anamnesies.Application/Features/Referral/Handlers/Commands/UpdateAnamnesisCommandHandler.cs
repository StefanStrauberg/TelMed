using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.Errors;
using Anamnesies.Application.Features.Referral.Requests.Commands;
using Anamnesies.Domain;
using AutoMapper;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Handlers.Commands
{
    public class UpdateAnamnesisCommandHandler : IRequestHandler<UpdateAnamnesisCommand>
    {
        private readonly IAnamnesisRepository _repository;
        private readonly IMapper _mapper;
        public UpdateAnamnesisCommandHandler(
            IAnamnesisRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateAnamnesisCommand request,
            CancellationToken cancellationToken)
        {
            if (await _repository.UpdateAsync(_mapper.Map<Anamnesis>(request.model), request.id))
                return Unit.Value;
            throw new AnamnesisBadRequestException(request.id);
        }
    }
}
