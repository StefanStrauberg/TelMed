using AutoMapper;
using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.DTO;
using Specializations.Application.Features.Specialization.Requests.Queries;
using Specializations.Application.Errors;

namespace Specializations.Application.Features.Specialization.Handlers.Queries
{
    public class GetSpecializationDetailRequestHandler : IRequestHandler<GetSpecializationDetailRequest, SpecializationDto>
    {
        private readonly ISpecializationRepository _repository;
        private readonly IMapper _mapper;
        public GetSpecializationDetailRequestHandler(
            ISpecializationRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<SpecializationDto> Handle(GetSpecializationDetailRequest request,
            CancellationToken cancellationToken)
        {
            var specialization = await _repository.GetAsync(request.id);
            if(specialization is null)
                throw new SpecializationBadRequestException(request.id);
            return _mapper.Map<SpecializationDto>(specialization);
        }
    }
}
