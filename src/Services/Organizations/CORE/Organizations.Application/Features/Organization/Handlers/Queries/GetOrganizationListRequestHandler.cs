using AutoMapper;
using BaseDomain.Specs;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.DTO;
using Organizations.Application.Features.Organization.Requests.Queries;
using Organizations.Application.GrpcServices;
using Organizations.Application.Specifications;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetOrganizationListRequestHandler : IRequestHandler<GetOrganizationListRequest, PagedList<OrganizationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetOrganizationListRequestHandler(
            IMapper mapper,
            IGrpcService grpcService,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<PagedList<OrganizationDto>> Handle(GetOrganizationListRequest request,
            CancellationToken cancellationToken) 
        {
            //await Parallel.ForEachAsync(data, async (x, CancellationToken) =>
            //{
            //    if(x.SpecializationIds is not null)
            //        x.SpecializationIds = await _grpcService.GetSpecNamesByListIds(x.SpecializationIds);
            //});
            var spec = new OrganizationsWithSpecification(request.querySpecParams);
            return new PagedList<OrganizationDto>(
                _mapper.Map<List<OrganizationDto>>(await _unitOfWork.Organizations.FindWithSpecificationAsync(spec)),
                await _unitOfWork.Organizations.CountAsync(spec),
                request.querySpecParams.PageIndex,
                request.querySpecParams.PageSize);
        }
    }
}
