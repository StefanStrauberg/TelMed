using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Features.Specialization.Requests.Queries;

namespace Specializations.Application.Features.Specialization.Handlers.Queries
{
    public class GetShortSpecializationsHandler : IRequestHandler<GetShortSpecializations, Object>
    {
        private readonly ISpecializationRepository _repository;
        public GetShortSpecializationsHandler(ISpecializationRepository repository)
            => _repository = repository;
        public async Task<object> Handle(GetShortSpecializations request, CancellationToken cancellationToken)
            => await _repository.GetShortSpecializaitons();
    }
}