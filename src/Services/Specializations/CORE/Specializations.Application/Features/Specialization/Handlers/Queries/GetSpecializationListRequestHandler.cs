using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Features.Specialization.Requests.Queries;

namespace Specializations.Application.Features.Specialization.Handlers.Queries
{
    public class GetSpecializationListRequestHandler : IRequestHandler<GetSpecializationListRequest, IReadOnlyList<Domain.Specialization>>
    {
        private readonly ISpecializationRepository _repository;
        public GetSpecializationListRequestHandler(ISpecializationRepository repository)
        {
            _repository = repository;
        }
        public async Task<IReadOnlyList<Domain.Specialization>> Handle(GetSpecializationListRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
