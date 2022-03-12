using AutoMapper;
using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.DTO;
using Specializations.Application.Exceptions;
using Specializations.Application.Features.Specialization.Requests.Queries;

namespace Specializations.Application.Features.Specialization.Handlers.Queries
{
    public class GetSpecializationDetailRequestHandler : IRequestHandler<GetSpecializationDetailRequest, SpecializationDto>
    {
        private readonly ISpecializationRepository _repository;
        private readonly IMapper _mapper;
        public GetSpecializationDetailRequestHandler(ISpecializationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<SpecializationDto> Handle(GetSpecializationDetailRequest request, CancellationToken cancellationToken)
        {
            var specialization = await _repository.GetAsync(request.Id);
            if(specialization is null)
                throw new NotFoundException(nameof(request), request.Id);
            return _mapper.Map<SpecializationDto>(specialization);
        }
    }
}
