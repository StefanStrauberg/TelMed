using AutoMapper;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Features.Organization.Requests.Commands;
using Organizations.Application.Errors;
using Organizations.Application.DTO;

namespace Organizations.Application.Features.Organization.Handlers.Commands
{
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateOrganizationCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateOrganizationCommand request, 
            CancellationToken cancellationToken)
        {
            var organizationToUpdate = await _unitOfWork.Organizations.GetByIdAsync(request.id);
            if (organizationToUpdate is null)
                throw new OrganizationNotFoundException(request.id.ToString());
            _mapper.Map(request.model, organizationToUpdate, typeof(CreateOrganizationDto), typeof(Domain.Organization));
            _unitOfWork.Organizations.Update(organizationToUpdate);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
