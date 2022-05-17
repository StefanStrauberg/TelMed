using AutoMapper;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.DTO;
using Organizations.Application.Features.Organization.Requests.Queries;
using Organizations.Application.GrpcServices;
using Organizations.Application.Specs;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetOrganizationListRequestHandler : IRequestHandler<GetOrganizationListRequest, PagedList<OrganizationDto>>
    {
        private readonly IOrganizationRepository _repository;
        private readonly IMapper _mapper;
        private readonly IGrpcService _grpcService;
        public GetOrganizationListRequestHandler(
            IOrganizationRepository repository,
            IMapper mapper,
            IGrpcService grpcService)
        {
            _repository = repository;
            _mapper = mapper;
            _grpcService = grpcService;
        }
        public async Task<PagedList<OrganizationDto>> Handle(GetOrganizationListRequest request,
            CancellationToken cancellationToken) 
        {
            var data = await _repository.GetAllAsync(request.querySpecParams);
            await Parallel.ForEachAsync(data, async (x, CancellationToken) =>
            {
                if(x.SpecializationIds is not null)
                    x.SpecializationIds = await _grpcService.GetSpecNamesByListIds(x.SpecializationIds);
            });
            return new PagedList<OrganizationDto>(
                _mapper.Map<List<OrganizationDto>>(data),
                await _repository.CountAsync(request.querySpecParams),
                request.querySpecParams.PageIndex,
                request.querySpecParams.PageSize);
        }
    }
}
