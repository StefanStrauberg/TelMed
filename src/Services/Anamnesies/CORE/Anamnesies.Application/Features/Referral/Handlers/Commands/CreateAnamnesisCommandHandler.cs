using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.Features.Referral.Requests.Commands;
using Anamnesies.Domain;
using AutoMapper;
using MassTransit;
using MediatR;
using MessageBus;

namespace Anamnesies.Application.Features.Referral.Handlers.Commands
{
    public class CreateAnamnesisCommandHandler : IRequestHandler<CreateAnamnesisCommand>
    {
        private readonly IAnamnesisRepository _repository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;
        public CreateAnamnesisCommandHandler(
            IAnamnesisRepository repository,
            IMapper mapper,
            IBus bus)
        {
            _repository = repository;
            _mapper = mapper;
            _bus = bus;
        }
        public async Task<Unit> Handle(CreateAnamnesisCommand request,
            CancellationToken cancellationToken)
        {
            // Check Contains AnamnesisCategory
            if(await _repository.ContainsAnamnesisCategoryAsync(request.model.CategoryId, request.model.ReferralId))
                return Unit.Value;
            // Create Anamnesis
            var anamnesis = await _repository.CreateAsync(_mapper.Map<Anamnesis>(request.model));
            // Adding AnamnesisId to Referral
            var endPoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://localhost/AnamnesisQueue"));
            await endPoint.Send(new Message { ReferralId = request.model.ReferralId ,Task = ReferralTask.POST, DataId = anamnesis });
            return Unit.Value;
        }
    }
}
