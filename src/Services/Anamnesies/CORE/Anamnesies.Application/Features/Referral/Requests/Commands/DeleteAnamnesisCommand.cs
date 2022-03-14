using MediatR;

namespace Anamnesies.Application.Features.Referral.Requests.Commands
{
    public class DeleteAnamnesisCommand : IRequest
    {
        public string Id { get; set; }
    }
}
