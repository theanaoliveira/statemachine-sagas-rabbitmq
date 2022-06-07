using MassTransit;
using Microsoft.Extensions.Logging;

namespace Samples.Sagas.ReadFile.Service.Masstransit.Consumers
{
    public class ReadFileConsumer : IConsumer<Contracts.File>
    {
        private readonly ILogger<ReadFileConsumer> logger;

        public ReadFileConsumer(ILogger<ReadFileConsumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<Contracts.File> context)
        {
            logger.LogInformation($"Consuming message {context.Message}");

            await Task.CompletedTask;
        }
    }
}
