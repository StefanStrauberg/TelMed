using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.Features.Referral.Requests.Commands;
using Anamnesies.Domain.Exceptions;
using MassTransit;
using MediatR;
using MessageBus;

namespace Anamnesies.Application.Features.Referral.Handlers.Commands
{
    public class DeleteAnamnesisCommandHandler : IRequestHandler<DeleteAnamnesisCommand>
    {
        private readonly IAnamnesisRepository _repository;
        private readonly IBus _bus;
        public DeleteAnamnesisCommandHandler(
            IAnamnesisRepository repository,
            IBus bus)
        {
            _repository = repository;
            _bus = bus;
        }
        public async Task<Unit> Handle(DeleteAnamnesisCommand request,
            CancellationToken cancellationToken)
        {
            string referralId = await _repository.GetReferralId(request.id);
            // Delete Anamnesis
            if (await _repository.DeleteAsync(request.id))
            {
                // Delete AnamnesisId to Referral
                var endPoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://localhost/AnamnesisQueue"));
                await endPoint.Send(new Message { ReferralId = referralId, Task = ReferralTask.DELETE, DataId = request.id });
                return Unit.Value;
            }
            throw new AnamnesisBadRequestException(request.id);
        }
    }
}
