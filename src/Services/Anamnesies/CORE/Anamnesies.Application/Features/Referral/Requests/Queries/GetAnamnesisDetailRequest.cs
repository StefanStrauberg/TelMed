using Anamnesies.Domain;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Requests.Queries
{
    public class GetAnamnesisDetailRequest : IRequest<Anamnesis>
    {
        public string Id { get; set; }
    }
}
