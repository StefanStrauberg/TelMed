using Anamnesies.Domain;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Requests.Queries
{
    public class GetAnamnesisListRequest : IRequest<IReadOnlyList<Anamnesis>>
    {
    }
}
