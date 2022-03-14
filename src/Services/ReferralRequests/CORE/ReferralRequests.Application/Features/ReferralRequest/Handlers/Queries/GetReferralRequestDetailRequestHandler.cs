using MediatR;
using ReferralRequests.Application.Contracts.Persistence;
using ReferralRequests.Application.Exceptions;
using ReferralRequests.Application.Features.ReferralRequest.Requests.Queries;

namespace ReferralRequests.Application.Features.ReferralRequest.Handlers.Queries
{
    public class GetReferralRequestDetailRequestHandler : IRequestHandler<GetReferralRequestDetailRequest, Domain.ReferralRequest>
    {
        private readonly IReferralRequestRepository _repository;
        public GetReferralRequestDetailRequestHandler(IReferralRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task<Domain.ReferralRequest> Handle(GetReferralRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var referralRequest = await _repository.GetAsync(request.Id);
            if (referralRequest is null)
                throw new NotFoundException(nameof(request), request.Id);
            return referralRequest;
        }
    }
}
