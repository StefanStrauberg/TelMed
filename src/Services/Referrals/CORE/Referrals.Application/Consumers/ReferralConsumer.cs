using MassTransit;
using MessageBus;
using Microsoft.Extensions.Logging;
using Referrals.Application.Contracts.Persistence;

namespace Referrals.Application.Consumers
{
    public class ReferralConsumer : IConsumer<Message>
    {
        private readonly IReferralRepository _repository;
        private readonly ILogger<ReferralConsumer> _logger;
        public ReferralConsumer(
            IReferralRepository repository,
            ILogger<ReferralConsumer> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<Message> context)
        {
            switch (context.Message.Task)
            {
                case ReferralTask.POST:
                    var crt = await _repository.AddAnamnesis(context.Message);
                    _logger.LogInformation($"Operation create: {crt}");
                    break;
                case ReferralTask.DELETE:
                    var del = await _repository.RemoveAnamnesis(context.Message);
                    _logger.LogInformation($"Operation delete: {del}");
                    break;
                default:
                    break;
            }


        }
    }
}