using MediatR;

namespace Specializations.Application.Features.Specialization.Requests.Queries
{
    public class GetSpecializationListRequest : IRequest<IReadOnlyList<Domain.Specialization>>
    {
    }
}
