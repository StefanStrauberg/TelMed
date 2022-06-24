using AutoMapper;
using BaseDomain.Specs;
using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.DTO;
using Specializations.Application.Features.Specialization.Requests.Queries;
using Specializations.Application.Specifications;

namespace Specializations.Application.Features.Specialization.Handlers.Queries
{
    public class GetSpecializationListRequestHandler : IRequestHandler<GetSpecializationListRequest, PagedList<SpecializationDto>>
    {
        private readonly ISpecializationQueryRepository _queryRepository;
        private readonly IMapper _mapper;
        public GetSpecializationListRequestHandler(
            IMapper mapper,
            ISpecializationQueryRepository queryRepository)
        {
            _mapper = mapper;
            _queryRepository = queryRepository;
        }
        public async Task<PagedList<SpecializationDto>> Handle(GetSpecializationListRequest request,
            CancellationToken cancellationToken)
        {
            var spec = new SpecializationsWithSpecification(request.querySpecParams);
            return new PagedList<SpecializationDto>(
                _mapper.Map<List<SpecializationDto>>(await _queryRepository.FindWithSpecificationAsync(spec)),
                await _queryRepository.CountAsync(spec),
                request.querySpecParams.PageIndex,
                request.querySpecParams.PageSize);
        }
    }
}
