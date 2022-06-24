using AutoMapper;
using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.DTO;
using Specializations.Application.Errors;
using Specializations.Application.Features.Specialization.Requests.Queries;

namespace Specializations.Application.Features.Specialization.Handlers.Queries
{
    public class GetSpecializationDetailRequestHandler : IRequestHandler<GetSpecializationDetailRequest, SpecializationDto>
    {
        private readonly ISpecializationQueryRepository _queryRepository;
        private readonly IMapper _mapper;
        public GetSpecializationDetailRequestHandler(
            IMapper mapper,
            ISpecializationQueryRepository queryRepository)
        {
            _mapper = mapper;
            _queryRepository = queryRepository;
        }
        public async Task<SpecializationDto> Handle(GetSpecializationDetailRequest request,
            CancellationToken cancellationToken)
        {
            var specialization = await _queryRepository.GetByIdAsync(request.id);
            if(specialization is null)
                throw new SpecializationBadRequestException(request.id.ToString());
            return _mapper.Map<SpecializationDto>(specialization);
        }
    }
}
