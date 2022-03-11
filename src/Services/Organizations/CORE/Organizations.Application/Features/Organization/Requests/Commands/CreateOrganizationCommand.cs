using MediatR;
using Organizations.Application.DTOs.Organization;

namespace Organizations.Application.Features.Organization.Requests.Commands
{
    public class CreateOrganizationCommand : IRequest<string>
    {
        public CreateOrganizationDto OrganizationDto { get; set; }
    }
}
