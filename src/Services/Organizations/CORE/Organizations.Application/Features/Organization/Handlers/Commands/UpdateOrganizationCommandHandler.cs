using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Features.Organization.Requests.Commands;
using Organizations.Domain.Exceptions;

namespace Organizations.Application.Features.Organization.Handlers.Commands
{
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand>
    {
        private readonly IOrganizationRepository _repository;
        private readonly IMapper _mapper;
        public UpdateOrganizationCommandHandler(
            IOrganizationRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateOrganizationCommand request, 
            CancellationToken cancellationToken)
        {
            if(await _repository.UpdateAsync(_mapper.Map<Domain.Organization>(request.model), request.Id))
                return Unit.Value;
            throw new OrganizationNotFoundException(request.Id);
        }
    }
}
