using MediatR;
using Organizations.Application.DTO;

namespace Organizations.Application.Features.Organization.Requests.Commands
{
    public record CreateOrganizationCommand(CreateOrganizationDto model) : IRequest;
}
