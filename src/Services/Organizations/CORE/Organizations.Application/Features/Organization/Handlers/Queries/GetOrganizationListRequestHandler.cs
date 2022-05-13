using AutoMapper;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.DTO;
using Organizations.Application.Features.Organization.Requests.Queries;
using Organizations.Application.GrpcServices;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetOrganizationListRequestHandler : IRequestHandler<GetOrganizationListRequest, IReadOnlyList<OrganizationDto>>
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
        public async Task<IReadOnlyList<OrganizationDto>> Handle(GetOrganizationListRequest request,
            CancellationToken cancellationToken) 
        {
            var result = await _repository.GetAllAsync(request.querySpecParams);
            await Parallel.ForEachAsync(result, async (x, CancellationToken) =>
            {
                if(x.SpecializationIds is not null)
                    x.SpecializationIds = await _grpcService.GetSpecNamesByListIds(x.SpecializationIds);
            });
            return _mapper.Map<IReadOnlyList<OrganizationDto>>(result);
        }
    }
}
