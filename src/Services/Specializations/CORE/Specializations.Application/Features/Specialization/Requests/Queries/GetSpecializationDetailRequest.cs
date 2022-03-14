using MediatR;

namespace Specializations.Application.Features.Specialization.Requests.Queries
{
    public class GetSpecializationDetailRequest : IRequest<Domain.Specialization>
    {
        public string Id { get; set; }
    }
}
