using MediatR;
using ReferralRequests.Application.Contracts.Persistence;
using ReferralRequests.Application.Features.ReferralRequest.Requests.Queries;

namespace ReferralRequests.Application.Features.ReferralRequest.Handlers.Queries
{
    public class GetReferralRequestListRequestHandler : IRequestHandler<GetReferralRequestListRequest, IReadOnlyList<Domain.ReferralRequest>>
    {
        private readonly IReferralRequestRepository _repository;
        public GetReferralRequestListRequestHandler(IReferralRequestRepository repository)
        {
            _repository = repository;
        }
        public Task<IReadOnlyList<Domain.ReferralRequest>> Handle(GetReferralRequestListRequest request, CancellationToken cancellationToken)
        {
            return _repository.GetAllAsync();
        }
    }
}
