using MediatR;

namespace ReferralRequests.Application.Features.ReferralRequest.Requests.Queries
{
    public class GetReferralRequestDetailRequest : IRequest<Domain.ReferralRequest>
    {
        public string Id { get; set; }
    }
}
