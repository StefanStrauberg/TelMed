using AutoMapper;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.DTO;
using Organizations.Application.Errors;
using Organizations.Application.Features.Organization.Requests.Queries;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetOrganizationDetailRequestHandler : IRequestHandler<GetOrganizationDetailRequest, OrganizationDetailDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetOrganizationDetailRequestHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<OrganizationDetailDto> Handle(GetOrganizationDetailRequest request, 
            CancellationToken cancellationToken)
        {
            var organization = await _unitOfWork.Organizations.GetByIdAsync(request.id);
            if (organization is null)
                throw new OrganizationBadRequestException(request.id.ToString());
            return _mapper.Map<OrganizationDetailDto>(organization);
        }
    }
}
