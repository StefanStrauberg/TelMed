using MediatR;

namespace Specializations.Application.Features.Specialization.Requests.Queries
{
    public record GetShortSpecializations : IRequest<Object>;
}