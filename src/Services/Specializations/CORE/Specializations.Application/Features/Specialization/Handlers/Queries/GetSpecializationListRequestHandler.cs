using AutoMapper;
using BaseDomain.Specs;
using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.DTO;
using Specializations.Application.Features.Specialization.Requests.Queries;

namespace Specializations.Application.Features.Specialization.Handlers.Queries
{
    public class GetSpecializationListRequestHandler : IRequestHandler<GetSpecializationListRequest, PagedList<SpecializationDto>>
    {
        private readonly ISpecializationRepository _repository;
        private readonly IMapper _mapper;
        public GetSpecializationListRequestHandler(
            ISpecializationRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<SpecializationDto>> Handle(GetSpecializationListRequest request,
            CancellationToken cancellationToken)
            => new PagedList<SpecializationDto>(
                _mapper.Map<List<SpecializationDto>>(await _repository.GetAllAsync(request.querySpecParams)),
                await _repository.CountAsync(request.querySpecParams),
                request.querySpecParams.PageIndex,
                request.querySpecParams.PageSize);
    }
}
