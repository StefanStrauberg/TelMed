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
        public override async Task<SpecName> GetSpecNameById(GetSpecIdRequest request, ServerCallContext context)
            => new SpecName() { Name = await _repository.GetAsync(request.Id) };
        public override async Task<SpecNamesList> GetSpecNamesByIds(GetSpecIdsRequestList request, ServerCallContext context)
            => _mapper.Map<SpecNamesList>(
                await _repository.GetSpecNamesByIds(_mapper.Map<List<string>>(request)));
    }
}
