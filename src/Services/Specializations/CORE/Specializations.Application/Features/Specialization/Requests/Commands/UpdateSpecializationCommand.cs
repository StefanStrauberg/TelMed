using MediatR;

namespace Specializations.Application.Features.Specialization.Requests.Commands
{
    public class UpdateSpecializationCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool DenyConsult { get; set; }
    }
}
