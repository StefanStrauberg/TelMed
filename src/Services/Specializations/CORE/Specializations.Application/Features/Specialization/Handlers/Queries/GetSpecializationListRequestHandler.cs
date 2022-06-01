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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetSpecializationListRequestHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<PagedList<SpecializationDto>> Handle(GetSpecializationListRequest request,
            CancellationToken cancellationToken)
        {
            var spec = new SpecializationsWithSpecification(request.querySpecParams);
            return new PagedList<SpecializationDto>(
                _mapper.Map<List<SpecializationDto>>(await _unitOfWork.Specializations.FindWithSpecificationAsync(spec)),
                await _unitOfWork.Specializations.CountAsync(spec),
                request.querySpecParams.PageIndex,
                request.querySpecParams.PageSize);
        }
    }
}
