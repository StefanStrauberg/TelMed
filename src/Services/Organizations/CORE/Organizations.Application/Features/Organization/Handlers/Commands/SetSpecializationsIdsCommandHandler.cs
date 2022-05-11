using AutoMapper;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Features.Organization.Requests.Commands;

namespace Organizations.Application.Features.Organization.Handlers.Commands
{
    public class SetSpecializationsIdsCommandHandler : IRequestHandler<SetSpecializationsIdsCommand>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationRepository _repository;
        public SetSpecializationsIdsCommandHandler(
            IOrganizationRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(SetSpecializationsIdsCommand request, CancellationToken cancellationToken)
        {
            await _repository.SetSpecializationIds(request.specializationIds, request.id);
            return Unit.Value;
        } 
    }
}