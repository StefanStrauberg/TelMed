using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Features.Specialization.Requests.Queries;

namespace Specializations.Application.Features.Specialization.Handlers.Queries
{
    public class GetSpecializationsCountRequestHandler : IRequestHandler<GetSpecializationsCountRequest, long>
    {
        private readonly ISpecializationRepository _repository;
        public GetSpecializationsCountRequestHandler(ISpecializationRepository repository)
            => _repository = repository;
        public Task<long> Handle(GetSpecializationsCountRequest request, CancellationToken cancellationToken)
            => _repository.CountAsync(request.querySpecParams);
    }
}