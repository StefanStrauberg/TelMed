using MediatR;

namespace Organizations.Application.Features.Organization.Requests.Commands
{
    public record DeleteOrganizationCommand(string id) : IRequest;
}
