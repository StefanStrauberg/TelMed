using MediatR;

namespace Specializations.Application.Features.Specialization.Requests.Commands
{
    public record DeleteSpecializationCommand(Guid id) : IRequest;
}
