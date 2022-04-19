using MediatR;

namespace Specializations.Application.Features.Specialization.Requests.Commands
{
    public record DeleteSpecializationCommand(string id) : IRequest;
}
