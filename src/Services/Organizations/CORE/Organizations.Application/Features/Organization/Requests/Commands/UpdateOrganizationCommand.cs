using MediatR;
using Organizations.Application.DTO;
using Organizations.Domain;

namespace Organizations.Application.Features.Organization.Requests.Commands
{
    public record UpdateOrganizationCommand(UpdateOrganizationDto model, Guid id) : IRequest;
}
