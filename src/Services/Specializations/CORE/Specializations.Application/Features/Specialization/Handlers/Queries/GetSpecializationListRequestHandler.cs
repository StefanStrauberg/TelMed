using AutoMapper;
using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.DTO;
using Specializations.Application.Features.Specialization.Requests.Queries;

namespace Specializations.Application.Features.Specialization.Handlers.Queries
{
    public class GetSpecializationListRequestHandler : IRequestHandler<GetSpecializationListRequest, IReadOnlyList<SpecializationDto>>
    {
        private readonly ISpecializationRepository _repository;
        private readonly IMapper _mapper;
        public GetSpecializationListRequestHandler(ISpecializationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<SpecializationDto>> Handle(GetSpecializationListRequest request, CancellationToken cancellationToken)
        {
            var specializations = await _repository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<SpecializationDto>>(specializations);
        }
    }
}
