using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.Features.Referral.Requests.Queries;
using Anamnesies.Domain;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Handlers.Queries
{
    public class GetAnamnesisListRequestHandler : IRequestHandler<GetAnamnesisListRequest, IReadOnlyList<Anamnesis>>
    {
        private readonly IAnamnesisRepository _repository;
        public GetAnamnesisListRequestHandler(
            IAnamnesisRepository repository)
        {
            _repository = repository;
        }
        public async Task<IReadOnlyList<Anamnesis>> Handle(GetAnamnesisListRequest request, CancellationToken cancellationToken)
        {
            var anamnesies = await _repository.GetAllAsync();
            return anamnesies;
        }
    }
}
