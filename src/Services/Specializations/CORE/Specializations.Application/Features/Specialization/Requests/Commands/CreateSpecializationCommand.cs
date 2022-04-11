using MediatR;

namespace Specializations.Application.Features.Specialization.Requests.Commands
{
    public class CreateSpecializationCommand : IRequest
    {
        public string Name { get; set; }
        public bool DenyConsult { get; set; }
    }
}
