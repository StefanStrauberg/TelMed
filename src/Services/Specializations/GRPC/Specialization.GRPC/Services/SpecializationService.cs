using Grpc.Core;
using Specialization.GRPC.Repositories;

namespace Specialization.GRPC.Services
{
    public class SpecializationService : SpecializationProtoService.SpecializationProtoServiceBase
    {
        private readonly ISpecializationRepository _repository;
        public SpecializationService(ISpecializationRepository repository)
            => _repository = repository;
        public override async Task<SpecName> GetSpecName(GetSpecRequest request, ServerCallContext context)
            => new SpecName() { Name = await _repository.GetAsync(request.Id) };
    }
}
