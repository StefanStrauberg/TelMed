using MediatR;
using Specializations.Application.DTO;

namespace Specializations.Application.Features.Specialization.Requests.Commands
{
    public record CreateSpecializationCommand(CreateSpecializationDto model) : IRequest;
}
