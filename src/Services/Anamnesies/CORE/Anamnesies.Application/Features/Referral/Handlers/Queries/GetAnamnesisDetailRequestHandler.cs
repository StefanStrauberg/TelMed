using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.DTO;
using Anamnesies.Application.Errors;
using Anamnesies.Application.Features.Referral.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Handlers.Queries
{
    public class GetAnamnesisDetailRequestHandler : IRequestHandler<GetAnamnesisDetailRequest, AnamnesisDto>
    {
        private readonly IAnamnesisRepository _repository;
        private readonly IMapper _mapper;
        public GetAnamnesisDetailRequestHandler(
            IAnamnesisRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<AnamnesisDto> Handle(GetAnamnesisDetailRequest request,
            CancellationToken cancellationToken)
        {
            var anamnesis = await _repository.GetAsync(request.id);
            if (anamnesis is null)
                throw new AnamnesisBadRequestException(request.id);
            return _mapper.Map<AnamnesisDto>(anamnesis);
        }
    }
}
