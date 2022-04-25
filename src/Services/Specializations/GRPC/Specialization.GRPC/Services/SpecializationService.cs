using AutoMapper;
using Grpc.Core;
using Specialization.GRPC.Repositories;

namespace Specialization.GRPC.Services
{
    public class SpecializationService : SpecializationProtoService.SpecializationProtoServiceBase
    {
        private readonly ISpecializationRepository _repository;
        private readonly IMapper _mapper;
        public SpecializationService(
            ISpecializationRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public override async Task<SpecName> GetDiscount(GetSpecRequest request, ServerCallContext context)
        {
            return _mapper.Map<SpecName>(await _repository.GetAsync(request.Id));
        }
    }
}
