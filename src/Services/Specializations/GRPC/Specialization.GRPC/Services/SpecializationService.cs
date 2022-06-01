using AutoMapper;
using Grpc.Core;
using Specializations.Application.Contracts.Persistence;

namespace Specialization.GRPC.Services
{
    public class SpecializationService : SpecializationProtoService.SpecializationProtoServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SpecializationService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public override async Task<SpecName> GetSpecNameById(GetSpecIdRequest request, ServerCallContext context)
            => new SpecName() { Name = (await _unitOfWork.Specializations.GetByIdAsync(new Guid(request.Id))).Name };
        public override async Task<SpecNamesList> GetSpecNamesByIds(GetSpecIdsRequestList request, ServerCallContext context)
        {
            var requestIds = _mapper.Map<List<Guid>>(request.Id);
            var result = await _unitOfWork.Specializations.FindWithExpressionAsync(x => requestIds.Contains(x.Id));
            return _mapper.Map<SpecNamesList>(result);
        }
    }
}
