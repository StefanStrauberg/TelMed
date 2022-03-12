using MediatR;

namespace Specializations.Application.Features.Specialization.Requests.Commands
{
    public class DeleteSpecializationCommand : IRequest
    {
        public string Id { get; set; }
    }
}
