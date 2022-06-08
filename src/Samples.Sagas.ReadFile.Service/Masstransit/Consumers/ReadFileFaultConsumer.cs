using MassTransit;
using Microsoft.Extensions.Logging;

namespace Samples.Sagas.ReadFile.Service.Masstransit.Consumers
{
    public class ReadFileFaultConsumer : IConsumer<Fault<Contracts.File>>
    {
        private readonly ILogger<ReadFileFaultConsumer> logger;

        public ReadFileFaultConsumer(ILogger<ReadFileFaultConsumer> logger)
        {
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<Fault<Contracts.File>> context)
        {
            logger.LogInformation($"Error {context.Message.Exceptions[0].Message}");
            logger.LogInformation($"Consuming message {context.Message.Message}");

            if (context.Message.Exceptions[0].Message.Equals("teste"))
            {
                return Task.CompletedTask;
            }

            return context.Publish<Contracts.File>(context.Message.Message);
        }
    }
}
