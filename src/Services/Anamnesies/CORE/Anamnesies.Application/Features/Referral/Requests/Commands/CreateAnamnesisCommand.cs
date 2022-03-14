using Anamnesies.Domain;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Requests.Commands
{
    public class CreateAnamnesisCommand : IRequest<string>
    {
        public string ReferralId { get; set; }
        public AnamnesisCategory CategoryId { get; set; }
        public string Summary { get; set; }
    }
}
