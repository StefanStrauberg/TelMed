using MediatR;

namespace ReferralRequests.Application.Features.ReferralRequest.Requests.Queries
{
    public class GetReferralRequestListRequest : IRequest<IReadOnlyList<Domain.ReferralRequest>>
    {
    }
}
