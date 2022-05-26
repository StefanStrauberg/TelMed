using MassTransit;
using MessageBus;
using Microsoft.Extensions.Logging;
using Referrals.Application.Contracts.Persistence;

namespace Referrals.Application.Consumers
{
    public class ReferralConsumer : IConsumer<Message>
    {
        private readonly IReferralRepository _repository;
        public ReferralConsumer(
            IReferralRepository repository)
        {
            _repository = repository;
        }
        public async Task Consume(ConsumeContext<Message> context)
        {
            switch (context.Message.Task)
            {
                case ReferralTask.POST:
                    await _repository.AddAnamnesis(context.Message);
                    break;
                case ReferralTask.DELETE:
                    await _repository.RemoveAnamnesis(context.Message);
                    break;
                default:
                    break;
            }


        }
    }
}