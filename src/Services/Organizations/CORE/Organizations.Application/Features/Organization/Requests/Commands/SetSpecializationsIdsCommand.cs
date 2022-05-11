using MediatR;
using Organizations.Application.DTO;

namespace Organizations.Application.Features.Organization.Requests.Commands
{
    public record SetSpecializationsIdsCommand(List<string> specializationIds, string id) : IRequest;
}