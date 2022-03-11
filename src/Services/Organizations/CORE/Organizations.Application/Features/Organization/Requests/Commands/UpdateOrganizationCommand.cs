using MediatR;
using Organizations.Application.DTOs.Organization;

namespace Organizations.Application.Features.Organization.Requests.Commands
{
    public class UpdateOrganizationCommand : IRequest
    {
        public UpdateOrganizationDto OrganizationDto { get; set; }
    }
}
