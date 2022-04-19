using MediatR;

namespace Organizations.Application.Features.Organization.Requests.Commands
{
    public record DeleteOrganizationCommand(string Id) : IRequest;
}
