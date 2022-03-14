using MediatR;

namespace ReferralRequests.Application.Features.ReferralRequest.Requests.Commands
{
    public class DeleteReferralRequestCommand : IRequest
    {
        public string Id { get; set; }
    }
}
