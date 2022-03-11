using MediatR;

namespace Organizations.Application.Features.Organization.Requests.Commands
{
    public class DeleteOrganizationCommand : IRequest
    {
        public string Id { get; set; }
    }
}
